using System.Threading.Tasks;

public class FreezingItem : BonusItem
{
    public override async void ActivateBonus(Player player)
    {
        var speed = player.Speed;

        player.Speed = 0;
        await Task.Delay(5000); 
        player.Speed = speed;
    }
}