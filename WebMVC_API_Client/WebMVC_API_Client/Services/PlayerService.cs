using WebMVC_API_Client.Helpers;
using WebMVC_API_Client.Models;
using WebMVC_API_Client.Services.Interfaces;

namespace WebMVC_API_Client.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Players/";

        public PlayerService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Player>> FindAll()
        {

            var responseGet = await _client.GetAsync(BasePath);

            var response = await responseGet.ReadContentAsync<List<Player>>();

            return response;
        }

        public async Task<Player> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Player>();

            var player = new Player(response.Id, response.Name, response.Number, response.Position, response.Line);

            return player;
        }
    }
}
