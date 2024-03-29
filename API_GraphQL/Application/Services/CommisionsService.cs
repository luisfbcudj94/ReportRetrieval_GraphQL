﻿using API_GraphQL.Application.Interfaces;
using API_GraphQL.DataManager.Paging;
using API_GraphQL.Domain.Models;
using Microsoft.AspNetCore.Http;

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
        public PaginatedList GetCommissionsPaginated(
                string? sincePostingDate = null,
                string? beforePostingDate = null,
                string? sinceCommissionId = null,
                string? orderId = null,
                string? affiliateNetwork = null,
                int pageNumber = 1,
                int pageSize = 25)
        {

            var data = _commissions_Paginated.Records;

            if (sincePostingDate != null && beforePostingDate != null)
            {
                var startDate = DateTime.Parse(sincePostingDate);
                var endDate = DateTime.Parse(beforePostingDate);

                if (startDate < DateTime.Today.AddYears(-20) || startDate > DateTime.Today.AddDays(1))
                {
                    throw new ArgumentException("sincePostingDate must be within the range of 20 years ago to today.");
                }

                if (endDate < DateTime.Today.AddYears(-20) || endDate > DateTime.Today.AddYears(20))
                {
                    throw new ArgumentException("beforePostingDate must be within the range from today minus 20 years to today plus 20 years.");
                }

                data = data.Where(p => p.PostingDate.Date >= startDate.Date && p.PostingDate.Date <= endDate.Date).ToList();
            }

            Guid orderIdGuid;
            if (Guid.TryParse(orderId, out orderIdGuid))
            {
                data = data.Where(p => p.OrderId == orderIdGuid).ToList();
            }

            if (!string.IsNullOrEmpty(affiliateNetwork))
            {
                data = data.Where(p => p.AffiliateNetwork == affiliateNetwork).ToList();
            }

            var result = data.
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).ToList();

            PaginatedList paginatedResult = new PaginatedList();
            paginatedResult.Records = result;
            paginatedResult.Count = data.Count;
            paginatedResult.MaxCommissionId = result.Count < pageSize ? null : result[result.Count - 1].CommissionId;
            paginatedResult.PayloadComplete = result.Count == 0 ? null : data[data.Count - 1] == result[result.Count - 1];
            paginatedResult.PageNumber = pageNumber;
            paginatedResult.PageSize = pageSize;

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
