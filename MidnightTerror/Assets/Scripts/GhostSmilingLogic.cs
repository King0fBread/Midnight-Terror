using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSmilingLogic : MonoBehaviour
{

    public void ContinueTheEndingSequence()
    {
        LanternAreaMovementManager.instance.EnableLeavingLanternArea();
    }
}
