namespace OOP_ICT.Second.Models;

public class Bank
{
    public void TransferToPlayer(Player player, decimal amount)
    {
        player.Account.Deposit(amount);
    }

    public void TransferFromPlayer(Player player, decimal amount)
    {
        player.Account.Withdraw(amount);
    }

    public bool CheckSufficientFunds(Player player, decimal amount)
    {
        return player.Account.HasSufficientFunds(amount);
    }
}