using OOP_ICT.Second.Models;

namespace OOP_ICT.Fifth.Services;
public class GameResult
{
    public Player Winner { get; set; }
    public List<Player> PlayersInGame { get; set; }
    public DateTime Timestamp { get; set; }
}