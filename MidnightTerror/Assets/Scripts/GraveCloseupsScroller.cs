using UnityEngine;

public class GraveCloseupsScroller : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

    [SerializeField] private GameObject _closeups;
    [SerializeField] private GameObject[] _closeupAreas;
    [SerializeField] private int _maxCloseupIndex;
    private int _closeupIndex;
    public void StartCloseups()
    {
        _closeups.SetActive(true);
        _closeupIndex = 0;
        _uiManager.HideAllDirectionButtons();

        EnableCurrentCloseup();

        SoundsManager.instance.PlayRandomWalkingSound();
    }
    public void HideCloseups()
    {
        _closeups.SetActive(false);
        _uiManager.ShowAllDirectionButtons();
    }
    public void EnableCurrentCloseup()
    {
        SoundsManager.instance.PlayRandomWalkingSound();

        if(_closeupIndex > _maxCloseupIndex)
        {
            HideCloseups();
        }
        else
        {
            foreach(var closeup in _closeupAreas)
            {
                if(closeup == _closeupAreas[_closeupIndex])
                {
                    closeup.SetActive(true);
                }
                else
                {
                    closeup.SetActive(false);
                }
            }
            _closeupIndex++;
        }

    }
}
