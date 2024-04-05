using Microsoft.EntityFrameworkCore;
using SampleCleanArchitecture.Application.Contracts.Persistence;
using SampleCleanArchitecture.Domain.Entities;

namespace SampleCleanArchitecture.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (!includePassedEvents)
            {
                foreach (var category in allCategories)
                {
                    category.Events.ToList().RemoveAll(p => p.Date < DateTime.Today);
                }
            }
            return allCategories;
        }
    }
}
