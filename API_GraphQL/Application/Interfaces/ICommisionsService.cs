using API_GraphQL.DataManager.Paging;
using API_GraphQL.Domain.Models;

namespace API_GraphQL.Application.Interfaces
{
    public interface ICommisionsService
    {
        /// <summary>
        /// Query to retrieve all available commissions.
        /// </summary>
        IQueryable<Commissions> GetCommissions();

        /// <summary>
        /// Query to retrieve paginated and filtered commissions of a publisher.
        /// </summary>
        /// <param name="sinceId">ID of commission from which to retrieve.</param>
        /// <param name="startDate">Start date of the date range to filter.</param>
        /// <param name="endDate">End date of the date range to filter.</param>
        /// <returns>A paginated list of publisher commissions.</returns>
        PaginatedList GetCommissionsPaginated
            (
                string? sincePostingDate = null,
                string? beforePostingDate = null,
                string? sinceCommissionId = null,
                string? orderId = null, 
                int pageNumber = 1, 
                int pageSize = 25
            );
    }
}
