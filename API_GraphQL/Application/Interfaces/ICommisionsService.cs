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
        PaginatedList GetCommissionsPaginated(DateTime sincePostingDate, DateTime beforePostingDate, Guid? sinceCommissionId = null, Guid? orderId = null);
    }
}
