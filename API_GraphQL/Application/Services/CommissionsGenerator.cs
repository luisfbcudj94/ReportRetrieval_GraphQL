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
            var uniqueGuids = Enumerable.Range(1, 300).Select(_ => Guid.NewGuid()).ToList();

            for (int i = 0; i < numberOfCommissions; i++)
            {
                commissionsList.Add(new Commissions
                {
                    CommissionId = Guid.NewGuid(),
                    AdvertiserName = GenerateAdvertiser(),
                    ActionType = i % 2 == 0 ? "Sale" : "Lead",
                    SaleAmountUsd = GenerateRandomDecimal(10, 1000),
                    OrderDiscountUsd = GenerateRandomDecimal(0, 100),
                    PubCommissionAmountUsd = GenerateRandomDecimal(1, 50),
                    ActionTrackerName = "ActionTracker" + i,
                    WebsiteName = "Website" + i,
                    Aid = "AID" + i,
                    //PostingDate = new DateTime(2024, 2, 27),
                    PostingDate = DateTime.UtcNow.AddDays(-GenerateRandomInt(1, 3)),
                    //EventDate = DateTime.UtcNow.AddDays(GenerateRandomInt(i,i+5)),
                    EventDate = new DateTime(2024, 2, 27),
                    OrderId = uniqueGuids[GenerateRandomInt(0, 299)],
                    Coupon = "Coupon" + i,
                    IsCrossDevice = GenerateRandomInt(i, i + 5) % 2 == 0,
                    AffiliateNetwork = GenerateAffiliateNetwork()
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
        static string GenerateAdvertiser()
        {
            List<string> data = new List<string>
            {
                "Walmart",
                "Amazon",
                "Carrefour",
                "Tesco",
                "Aldi",
                "Lidl",
                "Kmart",
                "Home Depot",
                "Lowe's",
                "Best Buy",
                "IKEA",
                "Auchan",
                "Bunnings Warehouse",
                "Big Lots",
                "Menards"
            };
            Random rnd = new Random();
            int index = rnd.Next(data.Count);
            return data[index];
        }
        static string GenerateAffiliateNetwork()
        {
            List<string> data = new List<string>
            {
                "Impact Radius",
                "Rakuten",
                "Commission Junction",
                "WildFire"
            };
            Random rnd = new Random();
            int index = rnd.Next(data.Count);
            return data[index];
        }

    }
}
