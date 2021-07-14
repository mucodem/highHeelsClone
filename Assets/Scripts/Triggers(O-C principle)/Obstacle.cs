using UnityEngine;
using HighHeels.TriggersSpace;
using HighHeels.GameManagerSpace;
using HighHeels.PlayerSpace;
using HighHeels.HillAdjusterSpace;


namespace HighHeels.ObstacleSpace
{
    public class Obstacle : Triggers
    {
        [SerializeField] int obsHeight;
        public override void TriggerFunc() // manages whole process
        {
            if (Player.instance.HillHeight >= obsHeight && Player.instance.trigger)
            {
                //Debug.Log(obsHeight);
                EnoughHeelLength();
            }
            else
            {
                NotEnoughHeelLength();
            }
        }
        void EnoughHeelLength() // if player has enough heel length to pass obstacle
        {
            Player.instance.HillHeight -= obsHeight;
            StartCoroutine(HillAdjuster.instance.ObstacleProcess(0.3f, -obsHeight, Player.instance.legs, Player.instance.transform, Player.instance.trigger));
        }
        void NotEnoughHeelLength()  //if player has NOT enough heel length to pass obstacle
        {
            Player.instance.lerpMul = 0;
            StartCoroutine(HillAdjuster.instance.ObstacleProcess(0, -Player.instance.legs[0].localScale.z, Player.instance.legs, Player.instance.transform, Player.instance.trigger));
            Player.instance.forwardSpeed = 0;
            Player.instance.anim.SetBool("fall", true);
            GameManager.instance.Activate();
        }
    }
}



