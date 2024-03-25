namespace FrontEnd_GraphQL.Application.Models.SetApis
{
    public class Header
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid ConfigurationId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        public virtual ICollection<HeaderTag>? HeaderTag { get; set; }
    }
}
