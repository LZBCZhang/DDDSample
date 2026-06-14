using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Application.UseCases.UpdateUserConsent;
using ConsentOrchestrator.Domain.Entities;
using ConsentOrchestrator.Domain.Events;
using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Domain.ValueObjects;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace ConsentOrchestrator.Tests.UseCases;

public class UpdateUserConsentHandlerTests
{
    private readonly Mock<IPurposeCacheService> _cacheMock = new();
    private readonly Mock<IOnetrustAdapterClient> _onetrustMock = new();
    private readonly Mock<IEventBus> _eventBusMock = new();
    private readonly Mock<IUnsubscribeLinkGenerator> _linkGenMock = new();
    private readonly UpdateUserConsentHandler _handler;

    public UpdateUserConsentHandlerTests()
    {
        _linkGenMock
            .Setup(x => x.Generate(It.IsAny<UserId>(), It.IsAny<CollectionPointId>(), It.IsAny<PurposeId>()))
            .Returns((UserId _, CollectionPointId _, PurposeId purposeId) =>
                new UnsubscribeLink(purposeId, $"https://consent.example.com/unsubscribe?purposeId={purposeId}"));

        _handler = new UpdateUserConsentHandler(
            _cacheMock.Object,
            _onetrustMock.Object,
            _eventBusMock.Object,
            _linkGenMock.Object,
            NullLogger<UpdateUserConsentHandler>.Instance);
    }

    private static Purpose MarketingPurpose(PurposeId id) =>
        new(id, "Marketing", "Marketing purpose",
            [new CommunicationChannel(Guid.NewGuid(), "EMAIL")]);

    private static UpdateUserConsentCommand Command(
        UserId userId, CollectionPointId collectionPointId, PurposeId purposeId, string correlationId) =>
        new(userId, collectionPointId, "web",
            [new ConsentDecision(purposeId, ConsentStatus.Confirmed, ["EMAIL"])],
            correlationId);

    [Fact]
    public async Task Handle_WhenPurposesInCache_ShouldNotCallOneTrustForPurposes()
    {
        var userId = UserId.From(Guid.NewGuid());
        var collectionPointId = CollectionPointId.From(Guid.NewGuid());
        var purposeId = PurposeId.From(Guid.NewGuid());

        _cacheMock
            .Setup(x => x.GetAsync(collectionPointId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Purpose> { MarketingPurpose(purposeId) });

        var result = await _handler.HandleAsync(Command(userId, collectionPointId, purposeId, "corr-123"));

        _onetrustMock.Verify(
            x => x.GetPurposesAsync(It.IsAny<CollectionPointId>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
            Times.Never);

        result.UnsubscribeLinks.Should().HaveCount(1);
    }

    [Fact]
    public async Task Handle_WhenPurposesNotInCache_ShouldCallOnetrustAndSetCache()
    {
        var userId = UserId.From(Guid.NewGuid());
        var collectionPointId = CollectionPointId.From(Guid.NewGuid());
        var purposeId = PurposeId.From(Guid.NewGuid());

        _cacheMock
            .Setup(x => x.GetAsync(collectionPointId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((IReadOnlyList<Purpose>?)null);

        _onetrustMock
            .Setup(x => x.GetPurposesAsync(collectionPointId, "corr-456", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Application.DTOs.Responses.PurposeResponse>
            {
                new(purposeId.Value, "Marketing", "Marketing purpose",
                    [new Application.DTOs.Responses.CommunicationResponse(Guid.NewGuid(), "EMAIL")])
            });

        await _handler.HandleAsync(Command(userId, collectionPointId, purposeId, "corr-456"));

        _onetrustMock.Verify(
            x => x.GetPurposesAsync(collectionPointId, "corr-456", It.IsAny<CancellationToken>()),
            Times.Once);

        _cacheMock.Verify(
            x => x.SetAsync(collectionPointId, It.IsAny<IReadOnlyList<Purpose>>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldPublishBothDomainEvents()
    {
        var userId = UserId.From(Guid.NewGuid());
        var collectionPointId = CollectionPointId.From(Guid.NewGuid());
        var purposeId = PurposeId.From(Guid.NewGuid());

        _cacheMock
            .Setup(x => x.GetAsync(collectionPointId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Purpose> { MarketingPurpose(purposeId) });

        await _handler.HandleAsync(Command(userId, collectionPointId, purposeId, "corr-789"));

        _eventBusMock.Verify(
            x => x.PublishAsync(It.IsAny<ConsentUpdated>(), It.IsAny<CancellationToken>()),
            Times.Once);

        _eventBusMock.Verify(
            x => x.PublishAsync(It.IsAny<UnsubscribeLinkGenerated>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldForwardConsentsToOnetrustAdapter()
    {
        var userId = UserId.From(Guid.NewGuid());
        var collectionPointId = CollectionPointId.From(Guid.NewGuid());
        var purposeId = PurposeId.From(Guid.NewGuid());

        _cacheMock
            .Setup(x => x.GetAsync(collectionPointId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Purpose> { MarketingPurpose(purposeId) });

        await _handler.HandleAsync(Command(userId, collectionPointId, purposeId, "corr-abc"));

        _onetrustMock.Verify(
            x => x.UpdateUserConsentsAsync(
                userId,
                collectionPointId,
                It.Is<IReadOnlyList<ConsentDecision>>(d => d.Count == 1 && d[0].PurposeId == purposeId),
                "corr-abc",
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
