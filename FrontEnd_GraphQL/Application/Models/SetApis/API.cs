
namespace FrontEnd_GraphQL.Application.Models.SetApis
{
    public class API
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? ApiTypeId { get; set; }
        public virtual string? Name { get; set; }
        public virtual APIType? APIType { get; set; }
        public virtual Configuration? Configuration { get; set; }
    }
}
