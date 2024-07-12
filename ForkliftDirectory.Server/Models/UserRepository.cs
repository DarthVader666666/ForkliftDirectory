using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Interfaces;

namespace ForkliftDirectory.Server.Models
{
    public class UserRepository : IRepository<User>
    {
        private readonly ForkliftDirectoryDbContext _dbContext;

        public UserRepository(ForkliftDirectoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User?> CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<User?> DeleteAsync(object? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetAsync(object? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User?>> GetListAsync()
        {
            return Task.FromResult(_dbContext.Users.AsEnumerable());
        }

        public Task<IEnumerable<User?>> GetListByAsync(object? criteria)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
