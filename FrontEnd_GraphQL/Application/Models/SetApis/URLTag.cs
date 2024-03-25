namespace FrontEnd_GraphQL.Application.Models.SetApis
{
    public class URLTag
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid UrlId { get; set; }
        public virtual Guid TagId { get; set; }
        public virtual Tag? Tags { get; set; }
    }
}
