namespace OOP_ICT.Second.Models;

public class BlackjackCasino
{
    public void AwardWin(Player player, decimal amount)
    {
        player.Account.Deposit(amount);
    }

    public void DeductLoss(Player player, decimal amount)
    {
        player.Account.Withdraw(amount);
    }

    public void HandleBlackjack(Player player, decimal amount)
    {
        decimal winnings = amount * 1.5m;
        AwardWin(player, winnings);
    }
}