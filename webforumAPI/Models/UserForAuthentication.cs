
using System.ComponentModel.DataAnnotations;

namespace webforumAPI.Models
{
    public class UserForAuthentication
    {
        //[Required]
        //public Guid id { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string? username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? password { get; set; }
    }
}

