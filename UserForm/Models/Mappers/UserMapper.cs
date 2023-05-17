using UserForm.Models.Domain_Models;
using UserForm.Models.RequestResponseModels;

namespace UserForm.Models.Mappers
{
    public static class UserMapper
    {
        public static User MapRequestToDomain(this UserRequestResponseModel source)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                ImagePath = source.ImagePath
            };
        }

        public static UserRequestResponseModel MapDomainToResponse(this User source)
        {
            return new UserRequestResponseModel
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                ImagePath=source.ImagePath
            };
        }
    }
}
