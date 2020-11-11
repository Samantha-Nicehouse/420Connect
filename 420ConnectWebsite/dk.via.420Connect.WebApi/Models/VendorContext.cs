using Microsoft.EntityFrameworkCore;

namespace dk.via._420Connect.WebApi.Models
{
    public class VendorContext : DbContext
    {
        public VendorContext(DbContextOptions<VendorContext> options)
            : base(options)
        {

        }

        public DbSet<Vendor> Vendors { get; set; }
    }
}