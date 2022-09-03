using System.Threading.Tasks;

public class SlowingItem : BonusItem
{
    public override async void ActivateBonus(Player player)
    {
        var divider = 2;
        
        player.Speed /= divider;
        await Task.Delay(5000);
        player.Speed *= divider;
    }
}
