using System;
using System.Collections.Generic;
using Xunit;
using NegotiationApi.Models;
using NegotiationApi.Services;

public class NegotiationServiceTest
{
    private readonly NegotiationService _negotiationService;

    public NegotiationServiceTest()
    {
        _negotiationService = new NegotiationService();
    }

    [Fact]
    public void ProposePrice_Should_Add_New_Negotiation()
    {
        var negotiation = new Negotiation { ProductId = 1, ProposedPrice = 500 };

        var result = _negotiationService.ProposePrice(negotiation);

        Assert.NotNull(result);
        Assert.Equal(500, result.ProposedPrice);
        Assert.Equal(1, result.AttemptCount);
        Assert.Equal(NegotiationStatus.Pending, result.Status);
    }

    [Fact]
    public void ProposePrice_Should_Throw_Exception_When_Price_Is_Zero()
    {
        var negotiation = new Negotiation { ProductId = 1, ProposedPrice = 0 };

        Assert.Throws<ArgumentException>(() => _negotiationService.ProposePrice(negotiation));
    }

    [Fact]
    public void RespondToNegotiation_Should_Accept_Negotiation()
    {
        var negotiation = new Negotiation { ProductId = 1, ProposedPrice = 500 };
        _negotiationService.ProposePrice(negotiation);

        var result = _negotiationService.RespondToNegotiation(1, true);

        Assert.Equal(NegotiationStatus.Accepted, result.Status);
    }

    [Fact]
    public void RespondToNegotiation_Should_Reject_Negotiation()
    {
        var negotiation = new Negotiation { ProductId = 1, ProposedPrice = 500 };
        _negotiationService.ProposePrice(negotiation);

        var result = _negotiationService.RespondToNegotiation(1, false);

        Assert.Equal(NegotiationStatus.Rejected, result.Status);
    }
}
