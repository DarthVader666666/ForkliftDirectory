using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForkliftDirectory.Server.Services
{
    public class MalfunctionRepository : IRepository<Malfunction>
    {
        private readonly ForkliftDirectoryDbContext _dbContext;

        public MalfunctionRepository(ForkliftDirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Malfunction?> CreateAsync(Malfunction item)
        {
            var result = await _dbContext.Malfunctions.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Malfunction?> DeleteAsync(object? id)
        {
            var malfunction = await GetAsync(id);
            var result = _dbContext.Remove(malfunction).Entity;
            await _dbContext.SaveChangesAsync();

            return result;
        }

        public Task<bool> ExistsAsync(Malfunction item)
        {
            throw new NotImplementedException();
        }

        public async Task<Malfunction?> GetAsync(object? id)
        {
            var malfunction = await _dbContext.Malfunctions.FirstOrDefaultAsync(x => x.MalfunctionId == (int?)id);
            return malfunction;
        }

        public Task<IEnumerable<Malfunction?>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Malfunction?>> GetListByAsync(object? criteria)
        {
            if (criteria == null)
            {
                return Task.FromResult<IEnumerable<Malfunction?>>(Enumerable.Empty<Malfunction?>());
            }

            var malfunctions = _dbContext.Malfunctions.Include(x => x.Forklift).Where(x => x.ForkliftId == (int?)criteria).AsEnumerable();

            return Task.FromResult<IEnumerable<Malfunction?>>(malfunctions);
        }

        public async Task<Malfunction?> UpdateAsync(Malfunction item)
        {
            Malfunction? result = null;

            if (item != null)
            {
                result = _dbContext.Malfunctions.Update(item).Entity;
                await _dbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}
