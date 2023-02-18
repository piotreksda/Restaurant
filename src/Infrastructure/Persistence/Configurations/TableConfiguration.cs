using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entites;

namespace Restaurant.Infrastructure.Persistence.Configurations
{
	public class TableConfiguration: IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.Property(t => t.SeatsCount)
            .IsRequired();
        }
    }
}

