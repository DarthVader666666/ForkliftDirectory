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

        public Task<Forklift?> CreateAsync(Forklift item)
        {
            throw new NotImplementedException();
        }

        public Task<Forklift?> DeleteAsync(object? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Forklift item)
        {
            throw new NotImplementedException();
        }

        public async Task<Forklift?> GetAsync(object? id)
        {
            var forklift = await _dbContext.Forklifts.Include(x => x.User).Include(x => x.Malfunctions)
                .FirstOrDefaultAsync(x => x.ForkliftId.Equals((string?)id));
            return forklift;
        }

        public Task<IEnumerable<Forklift?>> GetListAsync()
        {
            var forklifts = _dbContext.Forklifts.Include(x => x.User).Include(x => x.Malfunctions).ToList();
            return Task.FromResult<IEnumerable<Forklift?>>(forklifts);
        }

        public Task<IEnumerable<Forklift?>> GetListByAsync(object? criteria)
        {
            var forklifts = _dbContext.Forklifts.Include(x => x.User).Include(x => x.Malfunctions).AsEnumerable();
            var result = forklifts.Where(x => x.Number!.Contains((string?)criteria, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult<IEnumerable<Forklift?>>(result);
        }

        public Task<Forklift?> UpdateAsync(Forklift item)
        {
            throw new NotImplementedException();
        }
    }
}
