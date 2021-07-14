using UnityEngine;

namespace Mechanics
{
    public class SwipeMecLast : MonoBehaviour
    {
        #region Singleton
        public static SwipeMecLast instance = null;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        #endregion

        [Header("Variables to adjust")]
        [HideInInspector]public bool posSwipe = false; // if the game only use swerve for position set initial value true ,  //for rotation set initial value false    
        private float clampMaxVal; // min value will be minus of max. 
        private float lerpMult ;//lerp speed adjuster
     
        private Transform obj; // obj to swipe

        [Header("Others")]
        private float startPosX;
        private float deltaMousePos;
        private float clampedAngle;

        public void VariableAdjust(Transform objTocontrol, float lerpMultiplier, float clampMax, bool posActive) // start ta çağır
        {
            clampMaxVal = clampMax;
            lerpMult = lerpMultiplier;
            posSwipe = posActive;
            obj = objTocontrol;
            clampedAngle = 360 - clampMaxVal ; // because of euler angles
        }

        public void Swipe()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ResetValues();
            }
            else if (Input.GetMouseButton(0))
            {
                deltaMousePos = Input.mousePosition.x - startPosX;// how much mouse dragged

                if (posSwipe)//position swerve
                {
                    PositionMethod();
                }
                else ///rotation swerve
                {
                    RotationMethod1();
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {

            }
        }

        void ResetValues()
        {
            startPosX = Input.mousePosition.x;
        }

        void PositionMethod()
        {
            float xPos = obj.position.x;
            xPos = Mathf.Lerp(xPos, xPos + (5 * deltaMousePos / Screen.width), Time.deltaTime * lerpMult);
            xPos = Mathf.Clamp(xPos, -clampMaxVal, clampMaxVal);

            obj.position = new Vector3(xPos, obj.position.y, obj.position.z);
        }

        void RotationMethod1()
        {
            float zRot = obj.eulerAngles.y;
            zRot = Mathf.Lerp(zRot, zRot + (360 * deltaMousePos / Screen.width), Time.deltaTime * lerpMult);

            if (zRot > 180 && zRot < clampedAngle)
            {
                zRot = clampedAngle;
            }
            else if (zRot < 180 && zRot >= clampMaxVal)
            {
                zRot = clampMaxVal;
            }

            obj.eulerAngles = new Vector3(0, zRot, 0);
        }

        void RotationMethod2()
        {
            float zRot = Mathf.Lerp(0, (360 * deltaMousePos / Screen.width), Time.deltaTime * lerpMult);
            zRot = Mathf.Clamp(zRot, -clampMaxVal, clampMaxVal);
            Debug.Log(zRot);
            obj.eulerAngles -= new Vector3(0, -zRot, 0);
        }
    }
}

