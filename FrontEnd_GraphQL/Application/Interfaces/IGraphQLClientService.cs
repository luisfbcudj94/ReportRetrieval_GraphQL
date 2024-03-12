using GraphQL;

namespace FrontEnd_GraphQL.Application.Interfaces
{
    public interface IGraphQLClientService
    {
        Task<PaginatedList> SendQueryAsync<PaginatedList>(string query);
        Task<PaginatedList> SendQueryAsync<PaginatedList>(GraphQLRequest query);
    }
}
