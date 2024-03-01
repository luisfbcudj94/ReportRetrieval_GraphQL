using API_GraphQL.Application.Interfaces;
using API_GraphQL.Domain.Models;

namespace API_GraphQL.GraphQL
{
    public class Query
    {
        private readonly ICommisionsService _commisionsService;

        public Query(ICommisionsService commisionsService)
        {
            _commisionsService = commisionsService;
        }

        //[UsePaging(typeof(CommissionType))]
        //[HotChocolate.Data.UseFiltering]
        public IQueryable<Commissions> Comissions => _commisionsService.GetCommissions();
    }
}
