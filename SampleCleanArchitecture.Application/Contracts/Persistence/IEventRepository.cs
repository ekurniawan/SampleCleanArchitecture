using SampleCleanArchitecture.Domain.Entities;

namespace SampleCleanArchitecture.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
    }
}
