using SimulationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SimulationSystem.DAL
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SimulationContext : DbContext
    {
        public SimulationContext() : base("name=SimulationContext")
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Marker> Markers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Tracker> Trackers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SimulationContext>());
            base.OnModelCreating(modelBuilder);
        }
    }
}