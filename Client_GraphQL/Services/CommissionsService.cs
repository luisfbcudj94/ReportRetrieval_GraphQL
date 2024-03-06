using Client_GraphQL.Client;
using Client_GraphQL.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client_GraphQL.Services
{
    public class CommissionsService
    {
        public CommissionsService()
        {
       
        }

        public async Task RequestAllDataAsync(DateTime start_date, DateTime end_date)
        {
            var numberOfRequest = 0;
            try
            {
                GraphQLClient _graphQLClient = new GraphQLClient();
                CSVService _csvService = new CSVService();

                string? sinceId = Guid.Empty.ToString();

                var isCompleted = false;
                while (!isCompleted)
                {
                    var query = $@"
                    {{
                        publisherCommissions(
                            sinceId: ""{sinceId}""
                            startDate: ""{start_date.ToString("yyyy-MM-dd")}""
                            endDate: ""{end_date.ToString("yyyy-MM-dd")}""
                        ) {{
                            count
                            payloadComplete
                            maxId
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
                    numberOfRequest += 1;
                    Console.WriteLine("Making request number: " + numberOfRequest);
                    var response = await _graphQLClient.SendQueryAsync<dynamic>(query);
                    Console.WriteLine("Successfully completed request number: " + numberOfRequest);
                    var payloadComplete = response.publisherCommissions.payloadComplete.Value;
                    var maxId = response.publisherCommissions.maxId.Value;
                    List<Commissions> dataToExport = response.publisherCommissions.records.ToObject<List<Commissions>>();

                    Console.WriteLine($"Exporting data: from \n {response.publisherCommissions.records[0]} \n to \n {response.publisherCommissions.records[response.publisherCommissions.records.Count - 1]} \n");

                    _csvService.ExportData(dataToExport);

                    if (payloadComplete)
                    {
                        isCompleted = true;
                    }
                    else
                    {
                        sinceId = maxId;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        } 
    }
}
