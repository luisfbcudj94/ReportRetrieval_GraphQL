namespace API_GraphQL.DataManager.Paging
{
    public class PaginatedList<T>
    {
        public int Count{ get; set; }
        public bool PayloadComplete { get; set; }
        public int MaxId { get; set; }
        public List<T>? Records { get; set; }
    }
}
