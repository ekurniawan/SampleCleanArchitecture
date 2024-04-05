using SampleCleanArchitecture.Application.Contracts.Persistence;
using SampleCleanArchitecture.Domain.Entities;

namespace SampleCleanArchitecture.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
