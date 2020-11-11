using dk.via._420Connect.DataServer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace dk.via._420Connect.DataServer.Data
{
    public class VendorService : IVendorService
    {
        private string vendorFile = "vendors.json";
        private IList<Vendor> vendors;

        public VendorService()
        {
            if (!File.Exists(vendorFile))
            {
                Seed();
                WriteVendorToFile();
            }
            else
            {
                var content = File.ReadAllText(vendorFile);
                vendors = JsonSerializer.Deserialize<List<Vendor>>(content);
            }
        }

        public async Task<IList<Vendor>> GetVendors()
        {
            List<Vendor> tmp2 = new List<Vendor>(vendors);
            return tmp2;
        }

        public async Task<Vendor> GetById(int id)
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
            WriteVendorToFile();
        }

        public async Task EditVendorAsync(Vendor vendor)
        {
            vendor.Update(vendor);
        }

        private void vendorsFile()
        {
            var productsAsJson = JsonSerializer.Serialize(vendors);
            File.WriteAllText(vendorFile, productsAsJson);
        }
        public async Task RemoveVendorAsync(int Id)
        {
            var toRemove = vendors.First(t => t.VendorId == Id);
            vendors.Remove(toRemove);
            vendorsFile();
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
                    VendorBrandId = 1,
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
                    VendorBrandId = 2,
                    Email = "jkklkhihio@gmail.com",
                    PhoneNumber = 1234535,
                    City = "Wilmington",
                    Country = "USA"

                }
            };
            vendors = ps.ToList();
        }

        private void WriteVendorToFile()
        {
            var productsAsJson = JsonSerializer.Serialize(vendors);
            File.WriteAllText(vendorFile, productsAsJson);
        }

        public async Task UpdateVendorAsync(Vendor vendorToUpdate)
        {
            foreach (var item in vendors)
            {
                if (item.VendorId == vendorToUpdate.VendorId)
                {
                    item.Update(vendorToUpdate);
                }
            }
            vendorsFile();
        }
    }


}
