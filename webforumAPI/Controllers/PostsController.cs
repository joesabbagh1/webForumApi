using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webforumAPI.Models;

namespace webforumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly webForumDbContext _context;

        public PostsController(webForumDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await _context.posts.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var post = await _context.posts.FindAsync(id);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {

            await _context.posts.AddAsync(new Post()
            {
                id = Guid.NewGuid(),
                username = post.username,
                title = post.title,
                content = post.content,
                date_created = DateTime.UtcNow,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string request)
        {
            var posts = _context.posts.Where(post => post.title.Contains(request)).ToList();
            return posts == null ? NotFound() : Ok(posts);
        }
    }
}

