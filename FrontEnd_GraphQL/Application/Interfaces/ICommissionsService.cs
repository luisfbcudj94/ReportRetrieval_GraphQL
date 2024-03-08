using FrontEnd_GraphQL.Application.Models;
using FrontEnd_GraphQL.Helpers.Paging;

namespace FrontEnd_GraphQL.Application.Interfaces
{
    public interface ICommissionsService
    {
        Task<PublisherCommissions> GetCommissionsPaginated(DateTime sincePostingDate, DateTime beforePostingDate, string? sinceCommissionId = null);
    }
}
