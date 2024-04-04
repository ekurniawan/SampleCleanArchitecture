using MediatR;

namespace SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoriesWithEvents
{
    public class GetCategoriesWithEventsQuery : IRequest<List<CategoryEventListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
