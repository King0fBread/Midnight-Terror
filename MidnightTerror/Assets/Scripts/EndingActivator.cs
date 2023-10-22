using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingActivator : MonoBehaviour
{
    public void ActivateEndingArea()
    {
        LanternAreaMovementManager.instance.MoveToLanternArea();
    }
}
