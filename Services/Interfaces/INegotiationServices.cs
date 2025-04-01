using NegotiationApi.Models;

namespace NegotiationApi.Services.Interfaces
{
    public interface INegotiationServices
    {
        Negotiation ProposePrice(Negotiation negotiation);
        Negotiation GetNegotiationById(int id);
        Negotiation RespondToNegotiation(int id, bool accepted);
    }
}
