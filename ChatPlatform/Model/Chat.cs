using System;
using System.ComponentModel.DataAnnotations;

namespace ChatPlatform.Model
{
    public class Chat
    {
        [Key]
        public Guid ChatId { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
