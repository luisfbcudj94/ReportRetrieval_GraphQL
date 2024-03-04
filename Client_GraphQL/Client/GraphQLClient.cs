using Client_GraphQL.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Client_GraphQL.Client
{
    public class GraphQLClient
    {
        private GraphQLHttpClient graphQLClient = new GraphQLHttpClient("https://localhost:7012/graphql", new NewtonsoftJsonSerializer());


        public GraphQLClient()
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
    }
}
