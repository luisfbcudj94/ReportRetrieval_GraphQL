﻿using Client_GraphQL.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client_GraphQL.Services
{
    public class CSVService
    {
        public CSVService()
        {
            
        }

        public void ExportData(List<Commissions> newData)
        {
            try 
            {

                string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filesDirectory = Path.Combine(directoryPath, "files");
                if (!Directory.Exists(filesDirectory))
                {
                    Directory.CreateDirectory(filesDirectory);
                }

                string filePath = Path.Combine(filesDirectory, $"publisherCommissions.csv");

                List<Commissions> existingData = new List<Commissions>();

                if (File.Exists(filePath))
                {

                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        existingData = csv.GetRecords<Commissions>().ToList();
                    }
                }

                existingData.AddRange(newData);

                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(existingData);
                }

                Console.WriteLine("Data saved in the CSV file.");
                Console.WriteLine("File path: "+ filePath);
            } catch (Exception ex) 
            {
                throw;
            }

        }
    }
}
