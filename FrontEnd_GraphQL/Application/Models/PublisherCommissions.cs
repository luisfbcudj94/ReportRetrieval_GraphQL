namespace FrontEnd_GraphQL.Application.Models
{
    public class PublisherCommissions
    {
        public int Count { get; set; }
        public bool? PayloadComplete { get; set; }
        public string? MaxCommissionId { get; set; }
        public List<Commissions> Records { get; set; }
    }
}
