using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShackFunctionalArea : MonoBehaviour, IFunctionalArea
{
    [SerializeField] private Animator _ghostObjectAnimator;
    private bool _entranceMechanicFinished = false;
    public void ExecuteMechanicOnEntrance()
    {
        if (!_entranceMechanicFinished)
        {
            _ghostObjectAnimator.CrossFade("ShackGhostFadeAway", 0, 0);
        }
    }

    public void ExecuteMechanicOnLeaving()
    {
        
    }
}
