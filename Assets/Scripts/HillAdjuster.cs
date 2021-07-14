using System.Collections;
using UnityEngine;
using HighHeels.PlayerSpace;
using DG.Tweening;

namespace HighHeels.HillAdjusterSpace
{
    public class HillAdjuster : MonoBehaviour
    {
        #region Singleton

        public static HillAdjuster instance = null;

        private void Awake()
        {
            if (instance == null) instance = this;
        }

        #endregion
        public IEnumerator ObstacleProcess(float time, float obsHeight, Transform[] legs, Transform obj, bool trig) // Manages whole process
        {
            StartCoroutine(Timer(time, trig));
            Hill(obsHeight, legs);
            yield return new WaitForSeconds(time);      
            Reposition(obsHeight, obj);

        }

        public IEnumerator Timer(float time, bool trig) // prevent multiple triggerinng
        {
            trig = false;
            //Debug.Log(Player.instance.trigger);
            yield return new WaitForSeconds(time);
            trig = true;
        }

        public void Hill(float obsHeight, Transform[] legs) // heel ascender / descender
        {
            for (int i = 0; i <= 1; i++)
            {
                legs[i].DOScaleZ(legs[i].localScale.z + obsHeight , .1f).SetEase(Ease.Linear);
                legs[i].DOLocalMoveY(legs[i].localPosition.y + obsHeight / 2 , .1f).SetEase(Ease.Linear);

                //legs[i].localScale += new Vector3(0, 0, obsHeight);
                //legs[i].localPosition += new Vector3(0, obsHeight / 2, 0);
            }
        }

        public void Reposition(float value, Transform player) // reposition player
        {
             Player.instance.riggedCharacter.DOLocalMoveY(Player.instance.riggedCharacter.localPosition.y + value, 0.1f).SetEase(Ease.Linear);
             //Player.instance.riggedCharacter.position += new Vector3(0, value , 0);        
        }
    }
}
