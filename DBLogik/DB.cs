﻿using DBLogik.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DBLogik
{
    public class Database : DbContext
    {
        public Database() : base("BilForhandleren") {}

        //this.Database.Log = message => System.Diagnostics.Debug.WriteLine(message);

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Bruger> Bruger { get; set; }

        public DbSet<Bil> Biler { get; set; }
    }
}
