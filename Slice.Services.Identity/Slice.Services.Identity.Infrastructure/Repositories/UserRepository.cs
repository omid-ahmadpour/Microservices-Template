using Slice.Services.Identity.Core.Entities;
using Slice.Services.Identity.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Slice.Services.Identity.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
