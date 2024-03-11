using FrontEnd_GraphQL.Application.Models;

namespace FrontEnd_GraphQL.Application.Interfaces
{
    public interface ICSVService
    {
        byte[] ExportData(List<Commissions> newData);
    }
}
