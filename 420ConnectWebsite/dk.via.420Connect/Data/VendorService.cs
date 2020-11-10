using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using dk.via._420Connect.Model;

namespace dk.via._420Connect.Data
{
    public class VendorService : IVendorService
    {
        private string vendorsFile = "vendors.json";
        private IList<Vendor> vendors;

        public VendorService()
        {
            if (!File.Exists(vendorsFile))
            {
                Seed();
                WriteVendorsToFile();
            }
            else
            {
                var content = File.ReadAllText(vendorsFile);
                vendors = JsonSerializer.Deserialize<List<Vendor>>(content);
            }
        }

        public async Task<IList<Vendor>> GetVendorsAsync()
      
        {
            List<Vendor> tmp2 = new List<Vendor>(vendors);
            return tmp2;
        }

        public async Task<Vendor> GetVendorById(int id)
        {
            List<Vendor> tmp2 = new List<Vendor>(vendors);
            foreach (var item in tmp2)
            {
                if (item.VendorId == id)
                {
                    Vendor vendor = item;
                    return vendor;
                }
            }

            return null;
        }

        public async Task AddVendorAsync(Vendor vendor)
        {
            var max = vendors.Max(vendor => vendor.VendorId);
            vendor.VendorId = ++max;
            vendors.Add(vendor);
            WriteVendorsToFile();
        }
        
  

        private void vendorFile()
        {
            var productsAsJson = JsonSerializer.Serialize(vendors);
            File.WriteAllText(vendorsFile, productsAsJson);
        }
        public async Task RemoveVendorAsync(int Id)
        {
            var toRemove = vendors.First(t => t.VendorId == Id);
           vendors.Remove(toRemove);
            vendorFile();
        }
        private void Seed()
        {
            Vendor[] ps =
            {
                new Vendor

                {
                   
                    FirstName= "Yeshua",
                    LastName= "Magana",
                    VendorName= "Black",
                    VendorId= 11111,
                    Email = "snetteshe@gmail.com",
                    PhoneNumber = 111111111,
                    City = "Wilmington",
                    Country = "USA"
                    
                },
                new Vendor
                {
                    FirstName= "Joe",
                    LastName= "Trump",
                    VendorName= "BigCitySmoke",
                    VendorId= 13434311,
                    Email = "jkklkhihio@gmail.com",
                    PhoneNumber = 1234535,
                    City = "Wilmington",
                    Country = "USA"

                }
            };
            vendors = ps.ToList();
        }

        private void WriteVendorsToFile()
        {
            var productsAsJson = JsonSerializer.Serialize(vendors);
            File.WriteAllText(vendorsFile, productsAsJson);
        }

       
    }
    }
