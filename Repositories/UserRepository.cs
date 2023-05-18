using UserForm.Interfaces.IRepositories;
using UserForm.Models.Domain_Models;
using Microsoft.EntityFrameworkCore;

namespace UserForm.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserFormDbContext conetxt) : base(conetxt)
        { }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Find(user => user.Email.Equals(email))
            .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await Find(user => user.Id.Equals(id))
            .FirstOrDefaultAsync();
        }
    }
}
