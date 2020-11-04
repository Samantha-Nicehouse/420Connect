using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FourTwentyWebsite.Model;

namespace FourTwentyWebsite.Persistence
{
 
        public class FileContext
        {

            public IList<Vendor> Vendors { get; private set; }


            private readonly string vendorsFile = "vendors.json";

            public FileContext()
            {

                Vendors = File.Exists(vendorsFile) ? ReadData<Vendor>(vendorsFile) : new List<Vendor>();
            }

            private IList<T> ReadData<T>(string s)
            {
                using (var jsonReader = File.OpenText(s))
                {
                    return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
                }
            }

            public void SaveChanges()
            {
                // storing families

                // storing persons
                string jsonAdults = JsonSerializer.Serialize(Vendors, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                using (StreamWriter outputFile = new StreamWriter(vendorsFile, false))
                {
                    outputFile.Write(jsonAdults);
                }
            }
        }
    }
