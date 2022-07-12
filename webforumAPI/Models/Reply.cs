using System;
namespace webforumAPI.Models
{
    public class Reply
    {
        public Guid id { get; set; }
        public Guid user_id { get; set; }
        public Guid comment_id { get; set; }
        public string content { get; set; }
        public DateTime date_created { get; set; }
    }
}

