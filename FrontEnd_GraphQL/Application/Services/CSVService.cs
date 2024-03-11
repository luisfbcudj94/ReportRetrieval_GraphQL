using CsvHelper;
using FrontEnd_GraphQL.Application.Interfaces;
using FrontEnd_GraphQL.Application.Models;
using System.Globalization;
using System.Net.Mime;
using System.Reflection;

namespace FrontEnd_GraphQL.Application.Services
{
    public class CSVService: ICSVService
    {
        public CSVService()
        {
            
        }
        //public byte[] ExportData(List<Commissions> newData)
        //{
        //    try
        //    {

        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {

        //            using (var writer = new StreamWriter(memoryStream))
        //            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //            {
        //                csv.WriteRecords(newData);
        //            }


        //            return memoryStream.ToArray();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error exporting data to CSV.", ex);
        //    }
        //}
        public byte[] ExportData(List<Commissions> newData)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (var writer = new StreamWriter(memoryStream))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        // Especificar explícitamente las propiedades que deseas escribir
                        csv.WriteField("CommissionId");
                        csv.WriteField("AdvertiserName");
                        // Continuar con todas las propiedades que desees incluir en el archivo CSV

                        csv.NextRecord();

                        foreach (var commission in newData)
                        {
                            csv.WriteField(commission.CommissionId);
                            csv.WriteField(commission.AdvertiserName);
                            // Continuar con todas las propiedades que desees incluir en el archivo CSV

                            csv.NextRecord();
                        }
                    }

                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error exporting data to CSV.", ex);
            }
        }


    }
}
