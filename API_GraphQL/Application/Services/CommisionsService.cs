using API_GraphQL.Application.Interfaces;
using API_GraphQL.DataManager.Paging;
using API_GraphQL.Domain.Models;

namespace API_GraphQL.Application.Services
{
    /// <summary>
    /// Service class responsible for managing commissions data.
    /// </summary>
    public class CommisionsService: ICommisionsService
    {
        private readonly ICommissionsGenerator _commissionsGenerator;

        private List<Commissions> _commissionsList;

        private readonly PaginatedList _commissions_Paginated;
        private readonly int _pageSize = 1000;
        private readonly int _pageNumber = 1;

        /// <summary>
        /// Constructor for the CommisionsService class.
        /// </summary>
        /// <param name="commissionsGenerator">Service for generating commissions.</param>
        public CommisionsService(ICommissionsGenerator commissionsGenerator) 
        {
            _commissionsGenerator = commissionsGenerator;


            _commissionsList = new List<Commissions>();
            if (_commissionsList.Count == 0)
            {
                _commissionsList = GenerateData();
            }

            _commissions_Paginated = new PaginatedList();
            _commissions_Paginated.Records = _commissionsList;
        }

        /// <summary>
        /// Retrieves all commissions.
        /// </summary>
        /// <returns>An IQueryable representing all commissions.</returns>
        public IQueryable<Commissions> GetCommissions()
        {
            return _commissionsList.AsQueryable();
        }

        /// <summary>
        /// Retrieves paginated and filtered commissions.
        /// </summary>
        /// <param name="sinceId">ID of the commission to start pagination from.</param>
        /// <param name="startDate">Start date of the date range to filter.</param>
        /// <param name="endDate">End date of the date range to filter.</param>
        /// <returns>A paginated list of commissions.</returns>
        public PaginatedList GetCommissionsPaginated(Guid? sinceId = null, DateTime? startDate = null, DateTime? endDate = null)
        {

            var data = _commissions_Paginated.Records;
            var pageSize = _pageSize;
            var pageNumber = _pageNumber;

            int positionSinceId;

            if (startDate != null && endDate != null)
            {
                data = data.Where(p => p.EventDate >= startDate && p.EventDate <= endDate).ToList();
            }

            if (sinceId != null)
            {
                positionSinceId = data.FindIndex(p => p.CommissionId == sinceId);
                if (positionSinceId != -1)
                {
                    pageNumber = (int)Math.Floor((decimal)(positionSinceId + 1) / pageSize) + 1;
                }
                else
                {
                    data = new List<Commissions>();
                }
            }

            var result = data.
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).ToList();

            PaginatedList paginatedResult = new PaginatedList();
            paginatedResult.Records = result;
            paginatedResult.Count = data.Count;
            paginatedResult.MaxId = result.Count < _pageSize ? null :  result[result.Count - 1].CommissionId;
            paginatedResult.PayloadComplete = result.Count == 0 ? null : data[data.Count - 1] == result[result.Count - 1];

            return paginatedResult;
        }

        /// <summary>
        /// Method responsible for generating random data for the commissions.
        /// </summary>
        /// <returns>A list of commissions.</returns>
        private List<Commissions> GenerateData() 
            => _commissionsGenerator.GenerateCommissionsList(3500);
    }
}
