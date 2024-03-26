using FrontEnd_GraphQL.Application.Models.SetApis;

namespace FrontEnd_GraphQL.Application.Interfaces
{
    public interface IBuildRequestService
    {
        Task<string> CreateRequest(API data);
    }
}
