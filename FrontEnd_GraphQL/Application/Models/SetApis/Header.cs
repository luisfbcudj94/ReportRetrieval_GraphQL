namespace FrontEnd_GraphQL.Application.Models.SetApis
{
    public class Header
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? ConfigurationId { get; set; }
        public virtual HeaderTag? HeaderTag { get; set; }
    }
}
