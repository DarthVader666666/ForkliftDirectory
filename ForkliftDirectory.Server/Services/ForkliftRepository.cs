using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForkliftDirectory.Server.Services
{
    public class ForkliftRepository : IRepository<Forklift>
    {
        private readonly ForkliftDirectoryDbContext _dbContext;

        public ForkliftRepository(ForkliftDirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Forklift?> CreateAsync(Forklift forklift)
        {
            if (forklift != null)
            {
                await _dbContext.Forklifts.AddAsync(forklift);
                await _dbContext.SaveChangesAsync();
            }

            return forklift;
        }

        public async Task<Forklift?> DeleteAsync(object? id)
        {
            var forklift = await GetAsync(id);

            if (forklift != null)
            {
                _dbContext.Forklifts.Remove(forklift);
                await _dbContext.SaveChangesAsync();
            }
            
            return forklift;
        }

        public Task<bool> ExistsAsync(Forklift item)
        {
            throw new NotImplementedException();
        }

        public async Task<Forklift?> GetAsync(object? id)
        {
            var forklift = await _dbContext.Forklifts.Include(x => x.User).Include(x => x.Malfunctions)
                .FirstOrDefaultAsync(x => x.ForkliftId.Equals((int?)id));
            return forklift;
        }

        public Task<IEnumerable<Forklift?>> GetListAsync()
        {
            var forklifts = _dbContext.Forklifts.Include(x => x.User).Include(x => x.Malfunctions).ToList();
            return Task.FromResult<IEnumerable<Forklift?>>(forklifts);
        }

        public Task<IEnumerable<Forklift?>> GetListByAsync(object? criteria)
        {
            if (criteria == null)
            {
                return GetListAsync();
            }

            var forklifts = _dbContext.Forklifts.Include(x => x.User).Include(x => x.Malfunctions).AsEnumerable();
            var result = forklifts.Where(x => x.Number!.Contains((string?)criteria, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult<IEnumerable<Forklift?>>(result);
        }

        public async Task<Forklift?> UpdateAsync(Forklift? forklift)
        {
            if (forklift != null)
            {
                var result = _dbContext.Forklifts.Update(forklift);
                await _dbContext.SaveChangesAsync();
            }

            return forklift;
        }
    }
}
