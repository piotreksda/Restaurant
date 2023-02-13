using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Domain.Entites;

namespace Restaurant.Application.Tables.Queries.GetTables
{
	public record GetTablesQuery : IRequest<List<TableDto>>;
    public class GetTablesQueryHandler : IRequestHandler<GetTablesQuery, List<TableDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetTablesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TableDto>> Handle(GetTablesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Table
                .ProjectTo<TableDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}

