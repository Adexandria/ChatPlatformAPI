using System.ComponentModel.DataAnnotations;

namespace ChatPlatform.Model
{
    public class ChatCreate
    {
        // an object to create chat 
        [Required(ErrorMessage ="Enter username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Message")]
        public string Message { get; set; }
    }
}
