﻿using System;
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
            var comment = await _context.posts.FindAsync(id);
            return comment == null ? NotFound() : Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {

            await _context.comments.AddAsync(new Comment()
            {
                id = Guid.NewGuid(),
                user_id = comment.user_id,
                post_id = comment.post_id,
                content = comment.content,
                date_created = DateTime.UtcNow,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

