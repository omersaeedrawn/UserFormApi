using Microsoft.EntityFrameworkCore;
using UserForm.Models.Domain_Models;

namespace UserForm.Interfaces
{
    public interface IUserFormDbContext
    {
        DbSet<User> Users { get; set; }
    }
}
