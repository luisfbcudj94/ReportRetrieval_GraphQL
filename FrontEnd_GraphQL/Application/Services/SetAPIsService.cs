using FrontEnd_GraphQL.Application.Interfaces;
using FrontEnd_GraphQL.Application.Models.SetApis;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace FrontEnd_GraphQL.Application.Services
{
    public class SetAPIsService : ISetApisService
    {
        private readonly HttpClient _http;

        public SetAPIsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> CreateAsync(API input)
        {
            var result = await _http.PostAsJsonAsync<API>("https://localhost:7116/api/API", input);

            return result;
        }

        public async Task<List<HTTPMethods>> GetHttpMethods()
        {
            var result = await _http.GetFromJsonAsync<List<HTTPMethods>>("https://localhost:7116/api/HTTPMethod");

            return result;
        }

        public async Task<List<APIType>> GetTypesAPI()
        {
            var result = await _http.GetFromJsonAsync<List<APIType>>("https://localhost:7116/api/APIType");

            return result;
        }
    }
}
