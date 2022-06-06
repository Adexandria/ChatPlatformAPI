using ChatPlatform.Model;
using ChatPlatform.Service;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ChatPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        readonly IChat _chatDb;
        public ChatController(IChat _chatDb)
        {
            this._chatDb = _chatDb;
        }

        [HttpGet]
        public IActionResult GetChatHistory()
        {
            try
            {
                // get chat history from cookie
                string chatHistory = Request.Cookies["Chat"];
                //if chat history is empty return no chat history
                if (string.IsNullOrEmpty(chatHistory))
                {
                    return Ok("No chat history");
                }
                //split chat history.
                string[] chats = chatHistory.Split('.');

                return Ok(chats);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendMessage(ChatCreate message)
        {
            try
            {
                // map data from chatcreate object to chat object
                Chat newChat = message.Adapt<Chat>();
                //send data to database
                await _chatDb.AddMessage(newChat);
                //create a default cookie option
                CookieOptions cookie = new CookieOptions();
                //Get the updated messages from the database
                string currentHistory = _chatDb.UpdateCookie();
                //Add expiration date to the cookie
                cookie.Expires = DateTime.Now.AddMinutes(30);
                //add the message to the response cookie using the cookie option
                Response.Cookies.Append("Chat", currentHistory, cookie);

                return Ok("Sent");
               
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
