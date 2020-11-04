using System.Collections.Generic;
using System.Threading.Tasks;
using FourTwentyWebsite.Model;

namespace FourTwentyWebsite.Data
{
    public interface IVendorService
    {
      
            Task<IList<Vendor>> GetVendorsAsync();
            Task AddVendorAsync(Vendor vendor);

            Task<Vendor> GetVendorById(int Id);


    }
}