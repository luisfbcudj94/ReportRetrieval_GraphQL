﻿using Client_GraphQL.Client;
using Client_GraphQL.Models;
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

        public async Task RequestAllDataAsync()
        {
            GraphQLClient _graphQLClient = new GraphQLClient();

            string? sinceId = Guid.Empty.ToString();

            var isCompleted = false;
            while (!isCompleted)
            {
                var query = @"
                    query {
                      publisherCommissions(
                        sinceId: """ + sinceId + @""") {
                        count
                        payloadComplete
                        maxId
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
                    }
                ";

                var response = await _graphQLClient.SendQueryAsync<dynamic>(query);
                var payloadComplete = response.publisherCommissions.payloadComplete.Value;
                var maxId = response.publisherCommissions.maxId.Value;

                if (payloadComplete)
                {
                    isCompleted = true;
                }
                else
                {
                    sinceId = maxId;
                }

                Console.WriteLine($"Exporting data: from \n {response.publisherCommissions.records[0]} \n to \n {response.publisherCommissions.records[response.publisherCommissions.records.Count - 1]} \n");
            }
        } 
    }
}
