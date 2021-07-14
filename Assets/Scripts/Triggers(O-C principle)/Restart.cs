using HighHeels.TriggersSpace;
using HighHeels.GameManagerSpace;
using UnityEngine;

public class Restart : Triggers
{
    public override void TriggerFunc()
    {
        Time.timeScale = 0;
        GameManager.instance.Activate();
    }
}
