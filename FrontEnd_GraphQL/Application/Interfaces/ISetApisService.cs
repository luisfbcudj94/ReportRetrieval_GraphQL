using FrontEnd_GraphQL.Application.Models.SetApis;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd_GraphQL.Application.Interfaces
{
    public interface ISetApisService
    {
        Task<HttpResponseMessage> CreateAsync(API input);

        Task<List<APIType>> GetTypesAPI();
        Task<List<HTTPMethods>> GetHttpMethods();
    }
}
