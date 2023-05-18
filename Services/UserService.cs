using Microsoft.EntityFrameworkCore;
using UserForm.Interfaces.IRepositories;
using UserForm.Interfaces.IServices;
using UserForm.Models.Domain_Models;
using UserForm.Models.Mappers;
using UserForm.Models.RequestResponseModels;

namespace UserForm.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserRequestResponseModel> Create(UserRequestResponseModel model)
        {
            var oModel = model.MapRequestToDomain();
            await _userRepository.AddAsync(oModel);
            _userRepository.Complete();
            return oModel.MapDomainToResponse();

        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<bool> UpdateAsync(UserRequestResponseModel model)
        {
            var user = await _userRepository.Find(x => x.Id.Equals(model.Id))
                                                     .FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.ImagePath = model.ImagePath;

            await _userRepository.Update(user);

            _userRepository.Complete();

            return true;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userRepository.Remove(user);
            _userRepository.Complete();
        }
        public async Task<List<User>> GetAllAsync()
        {
            var data = await _userRepository.GetAll().ToListAsync();

            return data;
        }
    }
}