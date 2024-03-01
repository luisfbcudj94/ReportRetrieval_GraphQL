using API_GraphQL.Domain.Models;

namespace API_GraphQL.GraphQL
{
    public class CommissionType: ObjectType<Commissions>
    {
        protected override void Configure(IObjectTypeDescriptor<Commissions> descriptor)
        {
            descriptor.Field(x => x.CommissionId).Type<IdType>();
            descriptor.Field(x => x.AdvertiserName).Type<StringType>();
            descriptor.Field(x => x.ActionType).Type<StringType>();
            descriptor.Field(x => x.SaleAmountUsd).Type<DecimalType>();
            descriptor.Field(x => x.OrderDiscountUsd).Type<DecimalType>();
            descriptor.Field(x => x.PubCommissionAmountUsd).Type<DecimalType>();
            descriptor.Field(x => x.ActionTrackerName).Type<StringType>();
            descriptor.Field(x => x.WebsiteName).Type<StringType>();
            descriptor.Field(x => x.Aid).Type<StringType>();
            descriptor.Field(x => x.PostingDate).Type<DateTimeType>();
            descriptor.Field(x => x.EventDate).Type<DateTimeType>();
            descriptor.Field(x => x.OrderId).Type<StringType>();
            descriptor.Field(x => x.Coupon).Type<StringType>();
            descriptor.Field(x => x.IsCrossDevice).Type<BooleanType>();
        }
    }
}
