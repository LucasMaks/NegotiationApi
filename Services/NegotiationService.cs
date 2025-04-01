using NegotiationApi.Models;
using NegotiationApi.Services.Interfaces;

namespace NegotiationApi.Services
{
    public class NegotiationService : INegotiationServices
    {
        private readonly List<Negotiation> _negotiations =new List<Negotiation>();
        public Negotiation GetNegotiationById(int id)=> _negotiations.FirstOrDefault(n=>n.Id==id);

        public Negotiation ProposePrice(Negotiation negotiation)
        {
            if (negotiation.ProposedPrice <= 0)
                throw new ArgumentException("Proposed price must be greater than zero");

            var existinNegotiation=_negotiations.FirstOrDefault(n=>n.ProductId==negotiation.ProductId && n.Status==NegotiationStatus.Pending);

            if (existinNegotiation != null)
            {
                if (existinNegotiation.AttemptCount >= 3)
                {
                    existinNegotiation.Status = NegotiationStatus.Cancelled;
                    return existinNegotiation;
                }

                if ((DateTime.Now - existinNegotiation.LastProposalDate).TotalDays > 7)
                {
                    existinNegotiation.Status = NegotiationStatus.Cancelled;
                    return existinNegotiation;
                }
                existinNegotiation.ProposedPrice = negotiation.ProposedPrice;
                existinNegotiation.LastProposalDate = DateTime.Now;
                existinNegotiation.AttemptCount++;
                return existinNegotiation;
            }
            else 
            {
                negotiation.Id = _negotiations.Count + 1;
                negotiation.Status = NegotiationStatus.Pending;
                negotiation.AttemptCount = 1;
                negotiation.LastProposalDate=DateTime.Now;
                _negotiations.Add(negotiation);
                return negotiation;
            }
        }

        public Negotiation RespondToNegotiation(int id, bool accepted)
        {
           var negotiation= _negotiations.FirstOrDefault(n=>n.Id == id);
            if (negotiation != null)
                return null;

            if (negotiation.Status != NegotiationStatus.Pending) 
                throw new InvalidOperationException("Negoiation is not in a pending state.");
          
            negotiation.Status = accepted?NegotiationStatus.Accepted: NegotiationStatus.Rejected;
            return negotiation;
        }
    }
}
