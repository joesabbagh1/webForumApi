using System;
namespace webforumAPI.Models
{
    public class Comment
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public Guid post_id { get; set; }
        public string content { get; set; }
        public DateTime date_created { get; set; }
    }
}

