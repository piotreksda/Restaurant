using System;
using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entites;

namespace Restaurant.Application.TestEntities.Queries.GetTestEntity
{
	public class TestEntityDto : IMapFrom<TestEntity>
	{
		public Guid Id { get; set; }
		public int? SeatsCount { get; set; }
		public void Mapping(Profile profile)
        {
            profile.CreateMap<TestEntity, TestEntityDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SeatsCount, opt => opt.MapFrom(src => src.SeatsCount));
        }
    }
}

