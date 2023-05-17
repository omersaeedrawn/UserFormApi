using Microsoft.EntityFrameworkCore;
using UserForm.Interfaces;
using UserForm.Models.Domain_Models;

namespace UserForm.Repository
{
    public class UserFormDbContext: DbContext, IUserFormDbContext
    {
        public UserFormDbContext(DbContextOptions<UserFormDbContext> options)
            : base(options)
        {
        }

        public UserFormDbContext()

        {
        }
        public DbSet<User> Users{ get; set; }
    }
}
