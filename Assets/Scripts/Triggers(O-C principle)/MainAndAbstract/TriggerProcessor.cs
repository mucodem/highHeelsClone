using UnityEngine;
using HighHeels.TriggersSpace;
using HighHeels.PlayerSpace;


namespace HighHeels.TriggerProcessorSpace
{
    public class TriggerProcessor : MonoBehaviour
    {
        public Triggers triggers;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.GetComponent<Triggers>() != null)
            {
                triggers = other.GetComponent<Triggers>();
                triggers.TriggerFunc();
            }
        }
    }
}

