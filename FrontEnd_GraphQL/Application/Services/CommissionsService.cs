using BootstrapBlazor.Components;
using FrontEnd_GraphQL.Application.Interfaces;
using FrontEnd_GraphQL.Application.Models;
using FrontEnd_GraphQL.Helpers.Paging;
using GraphQL;
using GraphQL.Client.Abstractions;
using System;
using static System.Net.WebRequestMethods;

namespace FrontEnd_GraphQL.Application.Services
{
    public class CommissionsService: ICommissionsService
    {
        private readonly HttpClient _http;
        private readonly IGraphQLClientService _graphQLClientService;
        public CommissionsService(HttpClient http,
                                IGraphQLClientService graphQLClientService) 
        {
            _http = http;
            _graphQLClientService = graphQLClientService;
        }

        public async Task<PublisherCommissions> GetCommissionsPaginated(string? _sincePostingDate = null, string? _beforePostingDate = null, string? _sinceCommissionId = null, string? _orderId = null, int _pageNumber = 1, int _pageSize = 25)
        {

            if (_sinceCommissionId == null)
            {
                _sinceCommissionId = Guid.Empty.ToString();
            }

            var personAndFilmsRequest = new GraphQLRequest
            {
                Query = @"
                    query publisherCommissions(
                            $sincePostingDate: String,
                            $beforePostingDate: String,
                            $orderId: String,
                            $pageNumber: Int,
                            $pageSize: Int) {
                        publisherCommissions(
                            sincePostingDate: $sincePostingDate,
                            beforePostingDate: $beforePostingDate,
                            orderId: $orderId,
                            pageNumber: $pageNumber,
                            pageSize: $pageSize) {
                            count
                            payloadComplete
                            maxCommissionId
                            pageCount
                            pageNumber
                            pageSize
                            hasPrevious
                            hasNext
                            records {
                              commissionId
                              advertiserName
                              actionType
                              saleAmountUsd
                              orderDiscountUsd
                              pubCommissionAmountUsd
                              actionTrackerName
                              websiteName
                              aid
                              postingDate
                              eventDate
                              orderId
                              coupon
                              isCrossDevice
                            }
                        }
                    }",
                OperationName = "publisherCommissions",
                Variables = new
                {
                    sincePostingDate = _sincePostingDate,
                    beforePostingDate = _beforePostingDate,
                    orderId = _orderId,
                    pageNumber = _pageNumber,
                    pageSize = _pageSize,
                }
            };

            var response = await _graphQLClientService.SendQueryAsync<dynamic>(personAndFilmsRequest);

            PublisherCommissions data = new();

            data.PayloadComplete = response?.publisherCommissions?.payloadComplete?.Value;
            data.MaxCommissionId = response?.publisherCommissions?.maxCommissionId?.Value;
            data.Count = response?.publisherCommissions?.count;
            data.PageNumber = response?.publisherCommissions?.pageNumber;
            data.PageSize = response?.publisherCommissions?.pageSize;
            data.Records = response?.publisherCommissions.records.ToObject<List<Commissions>>();

            return data;

        }
    }
}
