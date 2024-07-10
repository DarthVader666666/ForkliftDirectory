using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Interfaces;

namespace ForkliftDirectory.Server.Services
{
    public class MalfunctionRepository : IRepository<Malfunction>
    {
        private readonly ForkliftDirectoryDbContext _dbContext;

        public MalfunctionRepository(ForkliftDirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Malfunction?> CreateAsync(Malfunction item)
        {
            throw new NotImplementedException();
        }

        public Task<Malfunction?> DeleteAsync(object? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Malfunction item)
        {
            throw new NotImplementedException();
        }

        public Task<Malfunction?> GetAsync(object? id)
        {
            throw new NotImplementedException();
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

            var malfunctions = _dbContext.Malfunctions.Where(x => x.ForkliftId == (int?)criteria).AsEnumerable();

            return Task.FromResult<IEnumerable<Malfunction?>>(malfunctions);
        }

        public Task<Malfunction?> UpdateAsync(Malfunction item)
        {
            throw new NotImplementedException();
        }
    }
}
