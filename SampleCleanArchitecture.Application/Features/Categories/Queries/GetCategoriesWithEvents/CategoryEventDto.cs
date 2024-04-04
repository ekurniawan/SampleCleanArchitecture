namespace SampleCleanArchitecture.Application.Features.Categories.Queries.GetCategoriesWithEvents
{
    public class CategoryEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Artist { get; set; } = null!;
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}