using UnityEngine;
using HighHeels.TriggersSpace;
using HighHeels.PlayerSpace;
using HighHeels.HillAdjusterSpace;
using HighHeels.GameManagerSpace;

namespace HighHeels.FinalStairsSpace
{
   public class FinalStairs : Triggers
    {
        [SerializeField] int obsHeight;

        public override void TriggerFunc() // collision progress
        {
            if (Player.instance.HillHeight >= obsHeight && Player.instance.trigger)
            {
                Player.instance.HillHeight -= obsHeight;
                StartCoroutine(HillAdjuster.instance.Timer(0.5f, Player.instance.trigger));
                HillAdjuster.instance.Hill(-obsHeight , Player.instance.legs);
            }
            else
            {
                Player.instance.bonus = true;
                GameManager.instance.Activate();
            }
        }
    }
}
   

