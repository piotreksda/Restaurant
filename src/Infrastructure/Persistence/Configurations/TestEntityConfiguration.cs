using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entites;

namespace Restaurant.Infrastructure.Persistence.Configurations
{
	public class TestEntityConfiguration: IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.Property(t => t.SeatsCount)
            .IsRequired();
        }
    }
}

