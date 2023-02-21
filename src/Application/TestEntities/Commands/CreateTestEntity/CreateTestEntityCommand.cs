using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Entites;
namespace Restaurant.Application.TestEntities.Commands.CreateTestEntity
{
	public record CreateTestEntityCommand : IRequest<Guid>
    {
        public int? SeatsCount { get; init; }
    }
    public class CreateTestEntityCommandHandler : IRequestHandler<CreateTestEntityCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateTestEntityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateTestEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = new TestEntity();
            entity.SeatsCount = request.SeatsCount;
            _context.TestEntities.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
            //return Guid.NewGuid();
        }
    }
}

