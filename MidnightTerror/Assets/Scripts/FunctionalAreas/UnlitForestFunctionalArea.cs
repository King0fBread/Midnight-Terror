using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlitForestFunctionalArea : MonoBehaviour, IFunctionalArea
{
    private bool _soundHasPlayed = false;
    public void ExecuteMechanicOnEntrance()
    {
        if (!_soundHasPlayed)
        {
            SoundsManager.instance.PlaySound(SoundsManager.Sounds.GhostLaughUnlitForest);
            _soundHasPlayed = true;
        }
    }

    public void ExecuteMechanicOnLeaving()
    {
        throw new System.NotImplementedException();
    }
}
