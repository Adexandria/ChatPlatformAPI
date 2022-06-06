using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMessage([FromBody]string message)
        {
            try
            {
                CookieOptions cookie = new CookieOptions();
                var oldMessage = Request.Cookies["Chat"];
                if (oldMessage != null)
                {
                    message = oldMessage + " " + message;
                }
                cookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Append("Chat", message,cookie);
                return Ok("Sent");
               
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
