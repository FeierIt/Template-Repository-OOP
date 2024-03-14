namespace OOP_ICT.Second.Models;
public class Player
{
    public string Name { get; }
    public Account Account { get; }

    public Player(string name, Account account)
    {
        Name = name;
        Account = account;
    }
}