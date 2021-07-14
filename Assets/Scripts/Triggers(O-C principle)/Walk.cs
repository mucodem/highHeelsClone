using HighHeels.TriggersSpace;
using Mechanics;
using UnityEngine;
using HighHeels.PlayerSpace;


    public class Walk : Triggers
    {
        public override void TriggerFunc()
        {
            if (!SwipeMecLast.instance.posSwipe)
            {

                transform.rotation = Quaternion.Euler(0, 0, 0);
                SwipeMecLast.instance.posSwipe = true;
                Debug.Log(true);
            }
            Player.instance.anim.SetBool("gap", false);
        }
    }

