using API_GraphQL.Application.Interfaces;
using API_GraphQL.DataManager.Paging;
using API_GraphQL.Domain.Models;

namespace API_GraphQL.GraphQL
{
    /// <summary>
    /// Class defining available queries in the GraphQL API.
    /// </summary>
    public class Query
    {
        private readonly ICommisionsService _commisionsService;

        /// <summary>
        /// Constructor of the Query class.
        /// </summary>
        /// <param name="commisionsService">Commission service for querying.</param>
        public Query(ICommisionsService commisionsService)
        {
            _commisionsService = commisionsService;
        }

        /// <summary>
        /// Query to retrieve all available commissions.
        /// </summary>
        //public IQueryable<Commissions> Commissions => _commisionsService.GetCommissions();

        /// <summary>
        /// Query to retrieve paginated and filtered commissions of a publisher.
        /// </summary>
        /// <param name="sinceId">ID of commission from which to retrieve.</param>
        /// <param name="startDate">Start date of the date range to filter.</param>
        /// <param name="endDate">End date of the date range to filter.</param>
        /// <returns>A paginated list of publisher commissions.</returns>
        public PaginatedList PublisherCommissions(string? sincePostingDate = null, string? beforePostingDate = null, string? sinceCommissionId = null, string? orderId = null, int pageNumber = 1, int pageSize = 25)
        {
            var response = _commisionsService.GetCommissionsPaginated(sincePostingDate, beforePostingDate, sinceCommissionId, orderId, pageNumber, pageSize);

            return response;
        }

    }
}
