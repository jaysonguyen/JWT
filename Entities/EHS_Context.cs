using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ehsproject.Entities
{
    public class EHS_Context : DbContext
    {
        public EHS_Context(DbContextOptions<EHS_Context> options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<FovRequest> FovRequests { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultDetail> ResultDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FovRequest>().HasKey(u => new
            {
                u.Count,
                u.SupplierCode,
                u.FovRequestID,
                u.Status,
            });
        }
    }
}