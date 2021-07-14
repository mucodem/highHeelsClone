using HighHeels.TriggersSpace;
using HighHeels.GameManagerSpace;
using HighHeels.PlayerSpace;



    public class CatWalk : Triggers
    {
        public override void TriggerFunc()
        {
            Player.instance.bonus = false;
            Player.instance.forwardSpeed = 0;
            Player.instance.anim.SetBool("catWalk", true);
            Player.instance.lerpMul = 0;
            GameManager.instance.Confetti();

            GameManager.instance.Activate();
        }
    }


