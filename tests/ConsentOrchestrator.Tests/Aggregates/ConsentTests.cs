using ConsentOrchestrator.Domain.Aggregates;
using ConsentOrchestrator.Domain.Entities;
using ConsentOrchestrator.Domain.Events;
using ConsentOrchestrator.Domain.Exceptions;
using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Domain.ValueObjects;
using FluentAssertions;
using Moq;

namespace ConsentOrchestrator.Tests.Aggregates;

public class ConsentTests
{
    private readonly UserId _userId = UserId.From(Guid.NewGuid());
    private readonly CollectionPointId _collectionPointId = CollectionPointId.From(Guid.NewGuid());
    private readonly PurposeId _purposeId = PurposeId.From(Guid.NewGuid());
    private readonly IUnsubscribeLinkGenerator _linkGenerator;

    public ConsentTests()
    {
        var mock = new Mock<IUnsubscribeLinkGenerator>();
        mock.Setup(x => x.Generate(It.IsAny<UserId>(), It.IsAny<PurposeId>()))
            .Returns((UserId _, PurposeId purposeId) => new UnsubscribeLink(purposeId, "https://example.com/u"));
        _linkGenerator = mock.Object;
    }

    private Purpose EmailPurpose() =>
        new(_purposeId, "Marketing", "Desc", [new CommunicationChannel(Guid.NewGuid(), "EMAIL")]);

    private Consent Record(IReadOnlyList<ConsentDecision> decisions, IReadOnlyList<Purpose> available) =>
        Consent.Record(_userId, _collectionPointId, "web", decisions, available, _linkGenerator);

    [Fact]
    public void Record_WithNoDecisions_Throws()
    {
        var act = () => Record([], [EmailPurpose()]);

        act.Should().Throw<InvalidConsentException>();
    }

    [Fact]
    public void Record_WithUnknownPurpose_Throws()
    {
        var decisions = new[] { new ConsentDecision(_purposeId, ConsentStatus.Confirmed, ["EMAIL"]) };

        var act = () => Record(decisions, []);

        act.Should().Throw<UnknownPurposeException>();
    }

    [Fact]
    public void Record_WithChannelNotOfferedByPurpose_Throws()
    {
        var decisions = new[] { new ConsentDecision(_purposeId, ConsentStatus.Confirmed, ["SMS"]) };

        var act = () => Record(decisions, [EmailPurpose()]);

        act.Should().Throw<InvalidConsentException>();
    }

    [Fact]
    public void Record_WithValidDecision_RaisesBothDomainEvents()
    {
        var decisions = new[] { new ConsentDecision(_purposeId, ConsentStatus.Confirmed, ["EMAIL"]) };

        var consent = Record(decisions, [EmailPurpose()]);

        consent.DomainEvents.Should().HaveCount(2);
        consent.DomainEvents.Should().ContainSingle(e => e is ConsentUpdated);
        consent.DomainEvents.Should().ContainSingle(e => e is UnsubscribeLinkGenerated);
        consent.UnsubscribeLinks.Should().HaveCount(1);
        consent.Id.Should().Be(new ConsentId(_userId, _collectionPointId));
    }

    [Fact]
    public void Record_ConsentUpdated_UsesWireFormatStatus()
    {
        var decisions = new[] { new ConsentDecision(_purposeId, ConsentStatus.Confirmed, ["EMAIL"]) };

        var consent = Record(decisions, [EmailPurpose()]);

        var updated = consent.DomainEvents.OfType<ConsentUpdated>().Single();
        updated.Purposes.Should().ContainSingle()
            .Which.Status.Should().Be("CONFIRMED");
    }

    [Fact]
    public void ClearDomainEvents_RemovesRaisedEvents()
    {
        var decisions = new[] { new ConsentDecision(_purposeId, ConsentStatus.Confirmed, ["EMAIL"]) };
        var consent = Record(decisions, [EmailPurpose()]);

        consent.ClearDomainEvents();

        consent.DomainEvents.Should().BeEmpty();
    }
}
