using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoriesWithEvents;
using SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoryList;

namespace SampleCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var results = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(results);
        }

        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            var result = await _mediator.Send(new GetCategoriesWithEventsQuery()
            {
                IncludeHistory = includeHistory
            });
            return Ok(result);
        }
    }
}

