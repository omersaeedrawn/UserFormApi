using System.ComponentModel.DataAnnotations;
using UserForm.Domain.Models;

namespace UserForm.Models.Domain_Models
{
    public class User : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
