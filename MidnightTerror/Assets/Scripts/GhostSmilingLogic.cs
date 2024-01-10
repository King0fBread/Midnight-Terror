using UnityEngine;

public class GhostSmilingLogic : MonoBehaviour
{

    public void ContinueTheEndingSequence()
    {
        LanternAreaMovementManager.instance.EnableLeavingLanternArea();
    }
}
