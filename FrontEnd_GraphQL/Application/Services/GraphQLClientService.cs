using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Serializer.Newtonsoft;
using FrontEnd_GraphQL.Application.Interfaces;

namespace FrontEnd_GraphQL.Application.Services
{
    public class GraphQLClientService: IGraphQLClientService
    {
        private GraphQLHttpClient graphQLClient = new GraphQLHttpClient("http://localhost:5222/graphql", new NewtonsoftJsonSerializer());

        //private GraphQLHttpClient graphQLClient = new GraphQLHttpClient("https://apigraphql20240305094849.azurewebsites.net/graphql", new NewtonsoftJsonSerializer());


        public GraphQLClientService()
        {
        }

        public async Task<PaginatedList> SendQueryAsync<PaginatedList>(string query)
        {
            try
            {
                var response = await graphQLClient.SendQueryAsync<dynamic>(query);

                if (response.Errors != null)
                {
                    foreach (var error in response.Errors)
                    {
                        Console.WriteLine($"Error: {error.Message}");
                    }
                }
                else
                {
                    var data = response.Data;
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while sending the query: {ex.Message}");
                throw;
            }
        }

        public async Task<PaginatedList> SendQueryAsync<PaginatedList>(GraphQLRequest query)
        {
            try
            {
                var response = await graphQLClient.SendQueryAsync<dynamic>(query);

                if (response.Errors != null)
                {
                    foreach (var error in response.Errors)
                    {
                        Console.WriteLine($"Error: {error.Message}");
                    }
                }
                else
                {
                    var data = response.Data;
                }

                return response.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while sending the query: {ex.Message}");
                throw;
            }
        }
    }
}
