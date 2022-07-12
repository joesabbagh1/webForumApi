
using System.ComponentModel.DataAnnotations;

namespace webforumAPI.Models
{
    public class User
    {
        [Required]
        public Guid id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime date_created { get; set; }
    }
}

