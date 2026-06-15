using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Application.DTOs.Responses;
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

    private readonly UserId _userId = UserId.From(Guid.NewGuid());
    private readonly CollectionPointId _collectionPointId = CollectionPointId.From(Guid.NewGuid());
    private readonly PurposeId _purposeId = PurposeId.From(Guid.NewGuid());
    private readonly Guid _communicationPreferenceId = Guid.NewGuid();
    private readonly Guid _optionId = Guid.NewGuid();

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

    private Purpose MarketingPurpose() =>
        new(_purposeId, "Marketing", "Marketing purpose", ConsentStatus.Confirmed, 1, "Marketing", _collectionPointId,
            [
                new CommunicationPreference(_communicationPreferenceId, "Email", "Email preference", 1,
                    CommunicationPreferenceType.Email,
                    [new PreferenceOption(_optionId, "Promotional", IsConsented: true)])
            ],
            []);

    private PurposeResponse MarketingPurposeResponse() =>
        new(_purposeId.Value, "Marketing", "Marketing purpose", "CONFIRMED", 1, "Marketing", _collectionPointId.Value,
            [
                new CommunicationPreferenceResponse(_communicationPreferenceId, "Email", "Email preference", 1, "EMAIL",
                    [new PreferenceOptionResponse(_optionId, "Promotional", true)])
            ],
            []);

    private UpdateUserConsentCommand Command(string correlationId) =>
        new(_userId, _collectionPointId, "web",
            [
                new ConsentDecision(_purposeId, ConsentStatus.Confirmed,
                    [
                        new CommunicationPreferenceDecision(_communicationPreferenceId,
                            [new PreferenceOption(_optionId, "Promotional", IsConsented: true)])
                    ],
                    [])
            ],
            correlationId);

    [Fact]
    public async Task Handle_WhenPurposesInCache_ShouldNotCallOneTrustForPurposes()
    {
        _cacheMock
            .Setup(x => x.GetAsync(_collectionPointId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Purpose> { MarketingPurpose() });

        var result = await _handler.HandleAsync(Command("corr-123"));

        _onetrustMock.Verify(
            x => x.GetPurposesAsync(It.IsAny<CollectionPointId>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
            Times.Never);

        result.UnsubscribeLinks.Should().HaveCount(1);
    }

    [Fact]
    public async Task Handle_WhenPurposesNotInCache_ShouldCallOnetrustAndSetCache()
    {
        _cacheMock
            .Setup(x => x.GetAsync(_collectionPointId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((IReadOnlyList<Purpose>?)null);

        _onetrustMock
            .Setup(x => x.GetPurposesAsync(_collectionPointId, "corr-456", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<PurposeResponse> { MarketingPurposeResponse() });

        await _handler.HandleAsync(Command("corr-456"));

        _onetrustMock.Verify(
            x => x.GetPurposesAsync(_collectionPointId, "corr-456", It.IsAny<CancellationToken>()),
            Times.Once);

        _cacheMock.Verify(
            x => x.SetAsync(_collectionPointId, It.IsAny<IReadOnlyList<Purpose>>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldPublishBothDomainEvents()
    {
        _cacheMock
            .Setup(x => x.GetAsync(_collectionPointId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Purpose> { MarketingPurpose() });

        await _handler.HandleAsync(Command("corr-789"));

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
        _cacheMock
            .Setup(x => x.GetAsync(_collectionPointId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Purpose> { MarketingPurpose() });

        await _handler.HandleAsync(Command("corr-abc"));

        _onetrustMock.Verify(
            x => x.UpdateUserConsentsAsync(
                _userId,
                _collectionPointId,
                It.Is<IReadOnlyList<ConsentDecision>>(d => d.Count == 1 && d[0].PurposeId == _purposeId),
                "corr-abc",
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}