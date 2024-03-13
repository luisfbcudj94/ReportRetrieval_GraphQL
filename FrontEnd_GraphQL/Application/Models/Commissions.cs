namespace FrontEnd_GraphQL.Application.Models
{
    public class Commissions
    {
        public Guid CommissionId { get; set; }
        public string AdvertiserName { get; set; }
        public string ActionType { get; set; }
        public decimal SaleAmountUsd { get; set; }
        public decimal OrderDiscountUsd { get; set; }
        public decimal PubCommissionAmountUsd { get; set; }
        public string ActionTrackerName { get; set; }
        public string WebsiteName { get; set; }
        public string Aid { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime EventDate { get; set; }
        public Guid OrderId { get; set; }
        public string Coupon { get; set; }
        public bool IsCrossDevice { get; set; }
        public string AffiliateNetwork { get; set; }
    }
}
