using API_GraphQL.Domain.Models;

namespace API_GraphQL.Application.Interfaces
{
    public interface ICommissionsGenerator
    {
        List<Commissions> GenerateCommissionsList(int numberOfCommissions);
    }
}
