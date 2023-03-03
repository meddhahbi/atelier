using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace Am.Infrastructure
{
    public class AmContext : DbContext
    {
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
