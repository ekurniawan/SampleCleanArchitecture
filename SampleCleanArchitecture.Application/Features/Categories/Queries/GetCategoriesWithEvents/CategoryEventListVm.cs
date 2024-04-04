﻿namespace SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoriesWithEvents
{
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}
