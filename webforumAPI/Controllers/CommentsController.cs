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
    public class CommentsController : ControllerBase
    {
        private readonly webForumDbContext _context;

        public CommentsController(webForumDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Comment>> Get()
        {
            return await _context.comments.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var comments = (
                from comment in _context.comments
                where comment.post_id == id
                select comment
                ).ToList();
            return comments == null ? NotFound() : Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {

            await _context.comments.AddAsync(new Comment()
            {
                id = Guid.NewGuid(),
                username = comment.username,
                post_id = comment.post_id,
                content = comment.content,
                date_created = DateTime.UtcNow,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

