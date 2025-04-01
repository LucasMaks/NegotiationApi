namespace NegotiationApi.Models
{
    public class Negotiation
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public decimal ProposedPrice { get; set; }
        public NegotiationStatus Status { get; set; }
        public int AttemptCount { get; set; }
        public DateTime LastProposalDate { get; set; }
    }
}
