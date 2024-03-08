using API_GraphQL.Domain.Models;

namespace API_GraphQL.DataManager.Paging
{
    public class PaginatedList
    {
        public int Count { get; set; }
        public bool? PayloadComplete { get; set; }
        public Guid? MaxCommissionId { get; set; }
        public List<Commissions> Records { get; set; }
    }
}
