using HighHeels.TriggersSpace;
using HighHeels.GameManagerSpace;
using System.Collections;
using UnityEngine;

public class Coin : Triggers
{
    public override void TriggerFunc()
    {
        GameManager.instance.GainCoin();

        Destroy(gameObject); // pooling pattern can be added
    }
}
