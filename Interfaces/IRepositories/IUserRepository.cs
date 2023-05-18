using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserForm.Models.Domain_Models;

namespace UserForm.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
    }
}
