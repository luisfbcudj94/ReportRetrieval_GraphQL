using BootstrapBlazor.Components;
using FrontEnd_GraphQL.Application.Interfaces;
using FrontEnd_GraphQL.Application.Models;
using FrontEnd_GraphQL.Helpers.Paging;
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

        public async Task<PublisherCommissions> GetCommissionsPaginated(DateTime sincePostingDate, DateTime beforePostingDate, string? sinceCommissionId = null, string? orderId = null)
        {

            if (sinceCommissionId == null)
            {
                sinceCommissionId = Guid.Empty.ToString();
            }

            orderId = orderId?.Replace(" ", "");
            Guid guid;
            if (string.IsNullOrEmpty(orderId) || !Guid.TryParse(orderId, out guid))
            {
                orderId = Guid.Empty.ToString();
            }

            var query = $@"
                {{
                    publisherCommissions(
                        sinceCommissionId: ""{sinceCommissionId}""
                        orderId: ""{orderId}""
                        sincePostingDate: ""{sincePostingDate.ToString("yyyy-MM-dd HH:mm:ss")}""
                        beforePostingDate: ""{beforePostingDate.ToString("yyyy-MM-dd HH:mm:ss")}""

                    ) {{
                        count
                        payloadComplete
                        maxCommissionId
                        records {{
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
                        }}
                    }}
                }}
                ";

            var response = await _graphQLClientService.SendQueryAsync<dynamic>(query);

            PublisherCommissions data = new();

            data.PayloadComplete = response?.publisherCommissions?.payloadComplete?.Value;
            data.MaxCommissionId = response?.publisherCommissions?.maxCommissionId?.Value;
            data.Count = response?.publisherCommissions?.count;
            data.Records = response?.publisherCommissions.records.ToObject<List<Commissions>>();

            //Console.WriteLine($"Exporting data: from \n {response.publisherCommissions.records[0]} \n to \n {response.publisherCommissions.records[response.publisherCommissions.records.Count - 1]} \n");

            //_csvService.ExportData(dataToExport);

            return data;

        }
    }
}
