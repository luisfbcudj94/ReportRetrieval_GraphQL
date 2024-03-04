using API_GraphQL.Domain.Models;

namespace API_GraphQL.DataManager.Paging
{
    public class PaginatedList
    {
        //public int Count => Records.Count;
        public int Count { get; set; }
        //public bool PayloadComplete => Records[Count - 1].CommissionId == MaxId;
        public bool? PayloadComplete { get; set; }
        //public Guid MaxId => Records[Count - 1].CommissionId;
        public Guid? MaxId { get; set; }
        public List<Commissions> Records { get; set; }
    }
}
