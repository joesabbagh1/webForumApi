using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace webforumAPI.Models
{
    public class User
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public DateTime date_created { get; set; }
    }
}

