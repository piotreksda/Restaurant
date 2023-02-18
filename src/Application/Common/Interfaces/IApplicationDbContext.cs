using System;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entites;

namespace Restaurant.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
        DbSet<Table> Table { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

