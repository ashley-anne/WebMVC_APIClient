using WebMVC_API_Client.Helpers;
using WebMVC_API_Client.Models;
using WebMVC_API_Client.Services.Interfaces;

namespace WebMVC_API_Client.Services
{
    public class Player : IPlayerService
    {
        private readonly HttpClient _client;
        private readonly object Position;
        private object Name;
        public const string BasePath = "/api/Players/";

        public HttpClient Id { get; private set; }
        public object Line { get; private set; }

        public Player(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Player(object id, object name, object line, object position)
        {
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

            var player = new Player(response.Id, response.Name, response.Line, response.Position);

            return player;
        }
    }
}
