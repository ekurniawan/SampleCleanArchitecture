using AutoMapper;
using SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoriesWithEvents;
using SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoryList;
using SampleCleanArchitecture.Application.Features.Events.Queries.GetEventsList;
using SampleCleanArchitecture.Domain.Entities;

namespace SampleCleanArchitecture.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();

            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Event, CategoryEventDto>();
        }
    }
}
