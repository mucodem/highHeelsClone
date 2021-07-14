using UnityEngine;
using Mechanics;

namespace HighHeels.PlayerSpace
{
    public class Player : MonoBehaviour
    {
        #region Singleton

        public static Player instance = null;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        #endregion

        public int HillHeight { get; set; }
        public Transform[] legs;

        [SerializeField] public float forwardSpeed;
        public float lerpMul;

        public bool bonus = false;
        public Animator anim;
        public bool trigger = true;

        [SerializeField]ParticleSystem[] particles = new ParticleSystem[2];

        public Transform riggedCharacter;

        public void Start()
        {
            HillHeight = 0;
        }


        void Update()
        {
            transform.Translate(transform.forward * forwardSpeed * Time.deltaTime);
            //rb.velocity = transform.forward * Time.deltaTime * speedMult;
            //rb.MovePosition(transform.forward* Time.deltaTime * speedMult);

            if (bonus)
            {
                Debug.Log("bonus gelindi");
                forwardSpeed = 0;
                anim.SetBool("dance", true);
                particles[0].Play();
                particles[1].Play();
                bonus = false;
            }
        }
    }
}

