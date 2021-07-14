using HighHeels.TriggersSpace;
using HighHeels.PlayerSpace;


    public class Gap : Triggers
    {
        public override void TriggerFunc()
        {
            Player.instance.anim.SetBool("gap", true);
        }
    }


