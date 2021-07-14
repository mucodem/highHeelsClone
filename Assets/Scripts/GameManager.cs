using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HighHeels.PlayerSpace;

namespace HighHeels.GameManagerSpace
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        public static GameManager instance = null;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        #endregion
        public Text coinTx;
        public GameObject restart;
        public ParticleSystem[] confettis = new ParticleSystem[4];

        public int coin;

        public void GainCoin()
        {
            for(int i = 0; i < 10; i++)
            {
                coin++;
                coinTx.text = coin.ToString();
            }    
        }


        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void Activate()
        {
            restart.SetActive(true);
        }

        public void Confetti()
        {
            for (int i = 0; i <= 3; i++)
            {
                confettis[i].Play();
            }
        }

    }
}

