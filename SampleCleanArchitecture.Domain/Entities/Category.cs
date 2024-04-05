using SampleCleanArchitecture.Domain.Common;

namespace SampleCleanArchitecture.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Event>? Events { get; set; }
    }
}
