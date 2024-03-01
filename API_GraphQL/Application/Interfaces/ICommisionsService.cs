using API_GraphQL.Domain.Models;

namespace API_GraphQL.Application.Interfaces
{
    public interface ICommisionsService
    {
        IQueryable<Commissions> GetCommissions();
    }
}
