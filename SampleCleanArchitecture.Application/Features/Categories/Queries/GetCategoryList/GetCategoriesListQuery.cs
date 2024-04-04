using MediatR;

namespace SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
