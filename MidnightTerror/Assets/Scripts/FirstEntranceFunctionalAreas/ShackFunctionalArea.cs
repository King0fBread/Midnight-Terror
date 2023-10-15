using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShackFunctionalArea : MonoBehaviour, IFirstEntranceFunctionalArea
{
    [SerializeField] private Animator _ghostObjectAnimator;
    public void ExecuteMechanicOnEntrance()
    {
        _ghostObjectAnimator.CrossFade("ShackGhostFadeAway", 0, 0);
    }

    public void ExecuteMechanicOnLeaving()
    {
        
    }
}
