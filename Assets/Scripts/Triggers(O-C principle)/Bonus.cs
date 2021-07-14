using HighHeels.TriggersSpace;
using HighHeels.PlayerSpace;

public class Bonus : Triggers
{
    public override void TriggerFunc()
    {
        if(Player.instance.HillHeight <= 0) Player.instance.bonus = true;
    }
}


