using Newtonsoft.Json;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fifth.Services;
public class PokerGameManager
{
    private List<Player> players;
    private List<GameResult> gameResults;

    public PokerGameManager()
    {
        players = new List<Player>();
        gameResults = new List<GameResult>();
    }

    public void AddPlayer(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Player name cannot be empty.");

        if (players.Any(p => p.Name == name))
            throw new ArgumentException("Player with this name already exists.");
        var acc = new Account(1000);
        players.Add(new Player(name, acc));
    }

    public void RecordGameResult(Player winner, List<Player> playersInGame)
    {
        if (winner == null)
            throw new ArgumentNullException(nameof(winner), "Winner cannot be null.");

        if (!playersInGame.Contains(winner))
            throw new ArgumentException("Winner must be one of the players in the game.");

        gameResults.Add(new GameResult
        {
            Winner = winner,
            PlayersInGame = playersInGame,
            Timestamp = DateTime.UtcNow
        });
    }

    public void SaveDataToJson()
    {
        string playersJson = JsonConvert.SerializeObject(players, Formatting.Indented);
        File.WriteAllText("players.json", playersJson);

        string gameResultsJson = JsonConvert.SerializeObject(gameResults, Formatting.Indented);
        File.WriteAllText("gameResults.json", gameResultsJson);
    }

    public void LoadDataFromJson()
    {
        if (File.Exists("players.json"))
        {
            string playersJson = File.ReadAllText("players.json");
            players = JsonConvert.DeserializeObject<List<Player>>(playersJson);
        }

        if (File.Exists("gameResults.json"))
        {
            string gameResultsJson = File.ReadAllText("gameResults.json");
            gameResults = JsonConvert.DeserializeObject<List<GameResult>>(gameResultsJson);
        }
    }
}
