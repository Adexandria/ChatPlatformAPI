using ChatPlatform.Model;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPlatform.Service
{
    public class ChatRepository : IChat
    {
        readonly DbService db;
        public ChatRepository(DbService db)
        {
            this.db = db;
        }
        public async Task AddMessage(Chat message)
        {
            try
            {
                //create a new guid key
                message.ChatId = Guid.NewGuid();
                //Add chat object to table
                await db.Chats.AddAsync(message);
                //save changes.
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdateCookie()
        {
            StringBuilder currentMessage = new StringBuilder();
            //Get chats and order by date
            IEnumerable<Chat> chats = db.Chats.OrderBy(s => s.Created);
            //Map chats to chatDTO object
            IEnumerable<ChatDTO> messages = chats.Adapt<IEnumerable<ChatDTO>>();
            //Append username to message
            foreach (var message in messages)
            {
                currentMessage.Append(message.Username);
                currentMessage.Append(":");
                currentMessage.Append(message.Message);
                currentMessage.Append(".");
            }
            return currentMessage.ToString();
        }
    }
}
