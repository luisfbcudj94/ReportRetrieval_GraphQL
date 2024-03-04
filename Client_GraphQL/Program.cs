using Client_GraphQL.Client;
using Client_GraphQL.Models;

var query = @"
        query {
            publisherCommissions {
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
GraphQLClient client = new GraphQLClient();

var data = await client.SendQueryAsync<dynamic>(query);

Console.ReadLine();