using FrontEnd_GraphQL.Application.Models;
using FrontEnd_GraphQL.Helpers.Paging;

namespace FrontEnd_GraphQL.Application.Interfaces
{
    public interface ICommissionsService
    {
        Task<PublisherCommissions> GetCommissionsPaginated(string? sincePostingDate = null, string? beforePostingDate = null, string? sinceCommissionId = null, string? orderId = null, int pageNumber = 1, int pageSize = 25);
    }
}
