namespace FrontEnd_GraphQL.Application.Models.SetApis
{
    public class Body
    {
        public virtual Guid? Id { get; set; }
        public virtual string Value { get; set; }
        public virtual ICollection<BodyTag>? BodyTag { get; set; }
    }
}
