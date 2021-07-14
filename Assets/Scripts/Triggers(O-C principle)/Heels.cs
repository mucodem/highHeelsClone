using HighHeels.HillAdjusterSpace;
using HighHeels.TriggersSpace;
using HighHeels.PlayerSpace;

    public class Heels : Triggers
    {
        public override void TriggerFunc()
        {
            Player.instance.HillHeight++;

            HillAdjuster.instance.Hill(1, Player.instance.legs);
            HillAdjuster.instance.Reposition(1, Player.instance.transform);

            Destroy(gameObject); // pooling pattern can be added
        }
    }

   

