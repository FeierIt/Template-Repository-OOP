using OOP_ICT.Fifth.Services;
using OOP_ICT.Fifth.UI;

class Program
{
    static void Main(string[] args)
    {
        var pokerGameManager = new PokerGameManager();
        var consoleInterface = new ConsoleInterface(pokerGameManager);

        pokerGameManager.LoadDataFromJson();

        consoleInterface.Start();

        pokerGameManager.SaveDataToJson();
    }
}