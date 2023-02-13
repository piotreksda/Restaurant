using System;
using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entites;

namespace Restaurant.Application.Tables.Queries.GetTables
{
	public class TableDto : IMapFrom<Table>
	{
		public Guid Id { get; set; }
		public int? SeatsCount { get; set; }
		public void Mapping(Profile profile)
		{
            profile.CreateMap<Table, TableDto>()
            .ForMember(d => d.SeatsCount, opt => opt.MapFrom(s => s.SeatsCount));
        }
	}
}

