using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via._420Connect.Model;

namespace dk.via._420Connect.Data
{
    public interface IVendorService
    {
      
            Task<IList<Vendor>> GetVendorsAsync();
            Task AddVendorAsync(Vendor vendor);

            Task<Vendor> GetVendorById(int Id);


    }
}