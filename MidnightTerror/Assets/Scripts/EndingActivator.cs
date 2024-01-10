using UnityEngine;

public class EndingActivator : MonoBehaviour
{
    public void ActivateEndingArea()
    {
        LanternAreaMovementManager.instance.MoveToLanternArea();
    }
}
