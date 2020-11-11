using dk.via._420Connect.DataServer.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dk.via._420Connect.DataServer.Data {
    public class CloudVendorService : IVendorService
    {

        private string uri1 = "https://localhost:44325/api";
        private readonly HttpClient client;

        public CloudVendorService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Vendor>> GetVendors()
        {
            Task<string> stringAsync = client.GetStringAsync(uri1 + "/Vendors");
            string message = await stringAsync;
            List<Vendor> result = JsonSerializer.Deserialize<List<Vendor>>(message);
            return result;
        }

        public async Task AddVendorAsync(Vendor vendor)
        {
            string vendorAsJson = JsonSerializer.Serialize(vendor);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PutAsync(uri1 + "/Vendors", content);
        }

        public async Task EditVendorAsync(Vendor vendor)
        {
            string vendorAsJson = JsonSerializer.Serialize(vendor);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri1}/Vendors/{vendor.VendorId}", content);
        }

        public async Task<Vendor> GetById(int Id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri1 + $"/Vendors/{Id}");
            string message = await stringAsync;
            Vendor result = JsonSerializer.Deserialize<Vendor>(message);
            return result;
        }

        public async Task RemoveVendorAsync(int vendorId)
        {
            await client.DeleteAsync($"{uri1}/Vendors/{vendorId}");
        }

        public async Task UpdateVendorAsync(Vendor vendor)
        {
            string vendorAsJson = JsonSerializer.Serialize(vendor);
            HttpContent content = new StringContent(vendorAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync($"{uri1}/Vendors/{vendor.VendorId}", content);
        }
    }
}