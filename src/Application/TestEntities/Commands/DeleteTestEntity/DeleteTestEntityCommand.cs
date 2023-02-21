using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Common.Interfaces;

namespace Restaurant.Application.TestEntities.Commands.DeleteTestEntity
{
	public record DeleteTestEntityCommand(Guid Id) : IRequest;
    public class DeleteTestEntityCommandHandler : IRequestHandler<DeleteTestEntityCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTestEntityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteTestEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TestEntities
                .Where(e => e.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity is null)
                throw new NotFoundException(nameof(TestEntities), request.Id);

            _context.TestEntities.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

