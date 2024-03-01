using API_GraphQL.Application.Interfaces;
using API_GraphQL.Domain.Models;

namespace API_GraphQL.Application.Services
{
    public class CommissionsGenerator: ICommissionsGenerator
    {
        public List<Commissions> GenerateCommissionsList(int numberOfCommissions)
        {
            var commissionsList = new List<Commissions>();

            for (int i = 0; i < numberOfCommissions; i++)
            {
                commissionsList.Add(new Commissions
                {
                    CommissionId = Guid.NewGuid().ToString(),
                    AdvertiserName = "Advertiser" + i,
                    ActionType = i % 2 == 0 ? "Sale" : "Lead",
                    SaleAmountUsd = GenerateRandomDecimal(10, 1000),
                    OrderDiscountUsd = GenerateRandomDecimal(0, 100),
                    PubCommissionAmountUsd = GenerateRandomDecimal(1, 50),
                    ActionTrackerName = "ActionTracker" + i,
                    WebsiteName = "Website" + i,
                    Aid = "AID" + i,
                    PostingDate = DateTime.UtcNow.AddDays(-i),
                    EventDate = DateTime.UtcNow.AddDays(-i),
                    OrderId = "Order" + i,
                    Coupon = "Coupon" + i,
                    IsCrossDevice = i % 2 == 0
                });
            }

            return commissionsList;
        }

        private decimal GenerateRandomDecimal(int min, int max)
        {
            Random random = new Random();
            return Math.Round((decimal)(min + (random.NextDouble() * (max - min))), 2);
        }
    }
}
