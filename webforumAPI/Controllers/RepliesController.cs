using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webforumAPI.Models;

namespace webforumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        private readonly webForumDbContext _context;

        public RepliesController(webForumDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Reply>> Get()
        {
            return await _context.replies.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var reply = await _context.replies.FindAsync(id);
            return reply == null ? NotFound() : Ok(reply);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reply reply)
        {

            await _context.replies.AddAsync(new Reply()
            {
                id = Guid.NewGuid(),
                username = reply.username,
                comment_id = reply.comment_id,
                content = reply.content,
                date_created = DateTime.UtcNow,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

