namespace FrontEnd_GraphQL.Application.Models.SetApis
{
    public class URL
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? HTTPMethodId { get; set; }
        public virtual string? Value { get; set; }
        public virtual ICollection<URLTag>? URLTag { get; set; }
        public virtual HTTPMethods? HttpMethods { get; set; }
    }
}
