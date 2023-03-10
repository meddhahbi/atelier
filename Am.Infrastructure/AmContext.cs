using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Am.Infrastructure.Config;

namespace Am.Infrastructure
{
    public class AmContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfig());
            modelBuilder.ApplyConfiguration(new PlaneConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());
           /* modelBuilder.Entity<Passanger>().Property(f => f.FirsName)
                 .HasColumnName("PassengerName")
                 .HasMaxLength(50)
                 .IsRequired().HasColumnType("varchar");*/
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(50);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<Double>().HavePrecision(2,3);
        }



        public DbSet<Flight> flights { get; set; }
        public DbSet<Passanger> passangers { get; set; }
        public DbSet<Etudiant> etudiants { get; set; }
        public DbSet<Personne> personnes { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Staff> staff { get; set; }
        public DbSet<Traveller> travellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source= (localdb)\mssqllocaldb; initial catalog= mohameddhahbi; integrated security= true");
        }

    }
}
