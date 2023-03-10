using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Am.Infrastructure.Config
{
    public class PassengerConfig : IEntityTypeConfiguration<Passanger>
    {
        public void Configure(EntityTypeBuilder<Passanger> builder)
        {
            builder.OwnsOne(f => f.fullName, h =>
            {
                h.Property(f => f.firstName).HasColumnName("FirstName").HasColumnType("varchar").HasMaxLength(20);
                h.Property(f => f.lastName).HasColumnName("LastName").HasColumnType("varchar").HasMaxLength(20);
            });
        }
    }
}
