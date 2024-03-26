namespace FrontEnd_GraphQL.Application.Models.SetApis
{
    public class Configuration
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? ApiId { get; set; }
        public virtual Guid? BodyId { get; set; }
        public virtual Guid? UrlId { get; set; }
        public virtual URL? URL { get; set; }
        public virtual Body? Body { get; set; }
        public virtual ICollection<Header>? Header { get; set; }
    }
}
