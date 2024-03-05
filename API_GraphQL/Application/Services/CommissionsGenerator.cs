using API_GraphQL.Application.Interfaces;
using API_GraphQL.Domain.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace API_GraphQL.Application.Services
{
    /// <summary>
    /// Service class responsible for generating mock commission data.
    /// </summary>
    public class CommissionsGenerator: ICommissionsGenerator
    {
        /// <summary>
        /// Generates a list of mock commissions.
        /// </summary>
        /// <param name="numberOfCommissions">The number of commissions to generate.</param>
        /// <returns>A list of mock commissions.</returns>
        public List<Commissions> GenerateCommissionsList(int numberOfCommissions)
        {
            var commissionsList = new List<Commissions>();

            for (int i = 0; i < numberOfCommissions; i++)
            {
                commissionsList.Add(new Commissions
                {
                    CommissionId = Guid.NewGuid(),
                    AdvertiserName = "Advertiser" + i,
                    ActionType = i % 2 == 0 ? "Sale" : "Lead",
                    SaleAmountUsd = GenerateRandomDecimal(10, 1000),
                    OrderDiscountUsd = GenerateRandomDecimal(0, 100),
                    PubCommissionAmountUsd = GenerateRandomDecimal(1, 50),
                    ActionTrackerName = "ActionTracker" + i,
                    WebsiteName = "Website" + i,
                    Aid = "AID" + i,
                    PostingDate = DateTime.UtcNow,
                    //EventDate = DateTime.UtcNow.AddDays(GenerateRandomInt(i,i+5)),
                    EventDate = new DateTime(2024, 2, 27),
                    OrderId =  Guid.NewGuid(),
                    Coupon = "Coupon" + i,
                    IsCrossDevice = GenerateRandomInt(i, i + 5) % 2 == 0
                });
            }

            return commissionsList;
        }

        private decimal GenerateRandomDecimal(int min, int max)
        {
            Random random = new Random();
            return Math.Round((decimal)(min + (random.NextDouble() * (max - min))), 2);
        }
        private int GenerateRandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }

    }
}
