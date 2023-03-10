using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Am.Infrastructure.Config
{
    public class FlightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("MyFlight");
            builder.HasKey(f => f.FlightId);

            builder.HasMany(f => f.passangers).WithMany(p => p.flights).UsingEntity(p => p.ToTable("flight_passenger"));
            builder.HasOne(f => f.plane).WithMany(p => p.flights).OnDelete(DeleteBehavior.SetNull);
            

        }
    }
}
