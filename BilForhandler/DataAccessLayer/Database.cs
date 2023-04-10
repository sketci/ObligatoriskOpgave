using BilForhandler.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilForhandler.DataAccessLayer
{
    public class Database : DbContext
    {
        public Database() : base("BilForhandleren") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Pris> Priser { get; set; }

        public DbSet<Bruger> Bruger { get; set; }

        public DbSet<Bil> Biler { get; set; }
    }
}
