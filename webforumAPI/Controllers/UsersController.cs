using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webforumAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webforumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly webForumDbContext _context;

        public UsersController(webForumDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _context.users.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.users.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {

            await _context.users.AddAsync(new User()
            {
                id = Guid.NewGuid(),
                username = user.username,
                password = user.password,
                date_created = DateTime.UtcNow,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

