using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttonsClockwiseFromTop = new Button[4];
    public void DisplayDirectionButtons(AreaStatus areaStatus)
    {
        int buttonId = 0;
        foreach(bool directionAvailability in areaStatus.GetDirectionsArray())
        {
            _buttonsClockwiseFromTop[buttonId].gameObject.SetActive(directionAvailability);
            buttonId++;
        }
    }
}
