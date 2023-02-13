using System;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;

namespace CSVHelperAndJsonDemo
{
	public class CSVHandler
	{
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = "/Users/piyushshaw/projects/CSVHelperAndJsonDemo/CSVHelperAndJsonDemo/Utility/Addresses.csv";
            string exportFilePath = "/Users/piyushshaw/projects/CSVHelperAndJsonDemo/CSVHelperAndJsonDemo/Utility/export.csv";

            //reading csv file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses csv.");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstname);
                    Console.Write("\t" + addressData.lastname);
                    Console.Write("\t" + addressData.address);
                    Console.Write("\t" + addressData.city);
                    Console.Write("\t" + addressData.state);
                    Console.Write("\t" + addressData.code);
                    Console.WriteLine();

                }
                Console.WriteLine("**********************Reading fromcsv file and Write to csv file **************************");
                //Writing csv file

                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
            //Console.WriteLine(reader);
        }




    }
}

