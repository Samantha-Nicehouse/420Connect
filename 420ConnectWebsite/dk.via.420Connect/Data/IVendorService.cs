using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via._420Connect.Model;

namespace dk.via._420Connect.Data
{
    public interface IVendorService
    {

        Task<IList<Vendor>> GetVendors();
        Task AddVendorAsync(Vendor adult);
        Task EditVendorAsync(Vendor adult);
        Task<Vendor> GetById(int Id);
        Task UpdateVendorAsync(Vendor vendorToUpdate);
        Task RemoveVendorAsync(int id);


    }
}