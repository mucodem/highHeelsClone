using UnityEngine;

namespace Mechanics
{
    public class SwipeController : MonoBehaviour
    {
        #region Singleton
        public static SwipeController instance = null;

        private void Awake()
        {
            if(instance == null)
                instance = this;
        }
        #endregion

        [Header("Variables")]
        public float lerp;
        public float clampMax;

        void Start()
        {
            SwipeMecLast.instance.VariableAdjust(transform, lerp, clampMax , true);
        }


        void Update()
        {
            SwipeMecLast.instance.Swipe();
        }
    }
}

