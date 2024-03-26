namespace FrontEnd_GraphQL.Application.Models.SetApis
{
    public class HeaderTag
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? HeaderId { get; set; }
        public virtual Guid? TagId { get; set; }
        public virtual Tag? Tag { get; set; }
    }
}
