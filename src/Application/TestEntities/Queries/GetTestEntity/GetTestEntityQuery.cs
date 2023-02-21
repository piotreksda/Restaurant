using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Entites;

namespace Restaurant.Application.TestEntities.Queries.GetTestEntity
{
	public record GetTestEntityQuery : IRequest<List<TestEntityDto>>;
    public class GetTestEntityQueryHandler : IRequestHandler<GetTestEntityQuery, List<TestEntityDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetTestEntityQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TestEntityDto>> Handle(GetTestEntityQuery request, CancellationToken cancellationToken)
        {
            return await _context.TestEntities
                .AsNoTracking()
                .ProjectTo<TestEntityDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}

