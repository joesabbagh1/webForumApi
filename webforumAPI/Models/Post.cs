﻿using System;
namespace webforumAPI.Models
{
    public class Post
    {
        public Guid id { get; set; }
        public Guid user_id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime date_created { get; set; }
    }
}

