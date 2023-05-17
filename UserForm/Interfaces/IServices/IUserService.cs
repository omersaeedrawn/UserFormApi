using UserForm.Models.Domain_Models;
using UserForm.Models.RequestResponseModels;

namespace UserForm.Interfaces.IServices
{
    public interface IUserService
    {
        Task<UserRequestResponseModel> Create(UserRequestResponseModel model);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(Guid id);
        Task DeleteUserAsync(User user);
        Task<bool> UpdateAsync(UserRequestResponseModel model);
    }
}
