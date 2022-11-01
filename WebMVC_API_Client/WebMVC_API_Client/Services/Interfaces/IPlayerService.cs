using WebMVC_API_Client.Models;

namespace WebMVC_API_Client.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> FindAll();

        Task<Player> FindOne(int id);
    }
}
