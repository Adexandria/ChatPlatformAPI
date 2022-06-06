using ChatPlatform.Model;
using System.Threading.Tasks;

namespace ChatPlatform.Service
{
    public interface IChat
    {
        Task AddMessage(Chat message);
        string UpdateCookie();
    }
}
