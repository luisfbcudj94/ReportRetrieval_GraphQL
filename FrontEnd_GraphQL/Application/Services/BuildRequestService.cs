using BootstrapBlazor.Components;
using FrontEnd_GraphQL.Application.Interfaces;
using FrontEnd_GraphQL.Application.Models.SetApis;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text.Json;

namespace FrontEnd_GraphQL.Application.Services
{
    public class BuildRequestService : IBuildRequestService
    {
        private readonly HttpClient _httpClient;

        public BuildRequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> CreateRequest(API data)
        {
            var url = data.Configuration?.URL?.Value ?? throw new ArgumentNullException("URL is mandatory");
            var body = data.Configuration?.Body?.Value ?? string.Empty;
            var apiType = data?.APIType?.Name ?? throw new ArgumentNullException("API Type is mandatory");
            var httpMethod = data?.Configuration?.URL?.HttpMethods?.Name ?? throw new ArgumentNullException("HTTP Method is mandatory");


            switch (apiType)
            {
                case "REST":
                    var response = await ProcessRestAPI(url, httpMethod);
                    return response;
                case "GraphQL":
                    //await ProcessGraphQLAPI(apiModel);
                    break;
                default:
                    throw new NotImplementedException("API type not supported");
            }



            return string.Empty;
        }

        private async Task<string> ProcessRestAPI(string url,string httpMethod)
        {
            switch (httpMethod)
            {
                case "GET":
                    var response = await _httpClient.GetFromJsonAsync<dynamic>(url);
                    string jsonResponse = JsonSerializer.Serialize(response);
                    return jsonResponse;
            }

            return string.Empty;
        }
    }
}
