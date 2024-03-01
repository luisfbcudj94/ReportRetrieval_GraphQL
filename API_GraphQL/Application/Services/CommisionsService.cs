using API_GraphQL.Application.Interfaces;
using API_GraphQL.Domain.Models;

namespace API_GraphQL.Application.Services
{
    public class CommisionsService: ICommisionsService
    {
        private readonly ICommissionsGenerator _commissionsGenerator;

        private List<Commissions> _commissionsList;
        public CommisionsService(ICommissionsGenerator commissionsGenerator) 
        {
            _commissionsGenerator = commissionsGenerator;


            _commissionsList = new List<Commissions>();
            if (_commissionsList.Count == 0)
            {
                _commissionsList = _commissionsGenerator.GenerateCommissionsList(1000);
            }
        }

        public IQueryable<Commissions> GetCommissions()
        {
            return _commissionsList.AsQueryable();
        }
    }
}
