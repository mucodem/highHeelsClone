using Mechanics;
using HighHeels.TriggersSpace;

public class Balance : Triggers
    {
        public override void TriggerFunc()
        {
            SwipeMecLast.instance.posSwipe = false;
        }
    }

