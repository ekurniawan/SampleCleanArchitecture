using AutoMapper;
using MediatR;
using SampleCleanArchitecture.Application.Contracts.Persistence;

namespace SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoriesWithEvents
{
    public class GetCategoriesWithEventsQueryHandle : IRequestHandler<GetCategoriesWithEventsQuery, List<CategoryEventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesWithEventsQueryHandle(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryEventListVm>> Handle(GetCategoriesWithEventsQuery request, CancellationToken cancellationToken)
        {
            var results = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVm>>(results);
        }
    }
}
