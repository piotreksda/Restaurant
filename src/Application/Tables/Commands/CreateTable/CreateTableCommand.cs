using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Entites;
namespace Restaurant.Application.Tables.Commands.CreateTable
{
	public record CreateTableCommand : IRequest<Guid>
    {
        public int? SeatsCount { get; init; }
    }
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateTableCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var entity = new Table();
            entity.SeatsCount = request.SeatsCount;
            _context.Table.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
            //return Guid.NewGuid();
        }
    }
}

