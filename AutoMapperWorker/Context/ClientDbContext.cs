using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperWorker.Context
{
    public class ClientDbContext<TIdentityKey, TClientKey> : DbContext
     where TIdentityKey : IEquatable<TIdentityKey>
     where TClientKey : IEquatable<TClientKey>
    {
        public ClientDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }




        public virtual DbSet<Client<TClientKey>> Clients { get; set; }
        public virtual DbSet<Tenant<TClientKey>> Tenants { get; set; }
    }
}
