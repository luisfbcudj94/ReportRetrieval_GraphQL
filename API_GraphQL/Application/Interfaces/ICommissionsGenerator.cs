using API_GraphQL.Domain.Models;

namespace API_GraphQL.Application.Interfaces
{
    public interface ICommissionsGenerator
    {
        /// <summary>
        /// Generates a list of mock commissions.
        /// </summary>
        /// <param name="numberOfCommissions">The number of commissions to generate.</param>
        /// <returns>A list of mock commissions.</returns>
        List<Commissions> GenerateCommissionsList(int numberOfCommissions);
    }
}
