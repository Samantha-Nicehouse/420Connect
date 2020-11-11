using System.Collections.Generic;
using System.Threading.Tasks;
using dk.via._420Connect.DataServer.Models;

namespace dk.via._420Connect.DataServer.Data
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