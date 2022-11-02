namespace WebMVC_API_Client.Models
{
    public class Player
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }
        public string? Position { get; set; }
        public string? Line { get; set; }

        public Player(int? id, string? name, int number, string? position, string? line)
        {

            Id = id;
            Name = name;
            Number = number;
            Position = position;
            Line = line;
        }
        public Player()
        {
            return;
        }
    }
}
