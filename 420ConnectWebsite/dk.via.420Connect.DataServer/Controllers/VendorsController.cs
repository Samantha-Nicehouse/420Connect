using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dk.via._420Connect.DataServer.Models;
using dk.via._420Connect.DataServer.Data;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace dk.via._420Connect.DataServer.Controllers
{
    [Route("ds/Vendors")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly VendorContext _context;
        private CloudVendorService ve = new CloudVendorService();

        public VendorsController(VendorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieve A List Of Vendors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            return await _context.Vendors.ToListAsync();
        }
        /// <summary>
        /// Retrieve A Vendor by given ID
        /// </summary>
        /// <param name="id">The id of the item to be retrieved</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            var adult = await _context.Vendors.FindAsync(id);

            if (adult == null)
            {
                return NotFound();
            }

            return adult;
        }
        /// <summary>
        /// Update Vendor at Given ID
        /// </summary>
        /// <param name="id">The id of the item to be updated</param>
        /// <param name="vendor">The object of the item used for update</param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> PostVendor(int id, Vendor vendor)
        {
            Vendor vendorToModify = await _context.Vendors.FindAsync(id);
            if (vendorToModify == null)
            {
                return NotFound();
            }
            else
            {
                vendorToModify.Update(vendor);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVendor), new { id = vendor.VendorId }, vendor);
        }
        /// <summary>
        /// Create A New Vendor
        /// </summary>
        /// <param name="vendor">The object of the item used for creation</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Vendor>> PutVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            await ValidateVendor(vendor);
            return CreatedAtAction(nameof(GetVendor), new { id = vendor.VendorId }, vendor);
        }
        /// <summary>
        /// Delete A Vendor at ID
        /// </summary>
        /// <param name="id">The ID of object to be removed</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendor>> DeleteVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return vendor;
        }
        /// <summary>
        /// Check if Vendor Exists at given iD
        /// </summary>
        /// <param name="id">The ID of object to be checked</param>
        /// <returns></returns>
        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.VendorId == id);
        }

        private async Task ValidateVendor(Vendor vendor)
        {
            await ve.AddVendorAsync(vendor);
        }
    }
}
