using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GraveCloseupsScroller : MonoBehaviour
{
    [SerializeField] private GameObject _closeups;
    [SerializeField] private GameObject[] _closeupAreas;
    [SerializeField] private int _maxCloseupIndex;
    private int _closeupIndex;
    public void StartCloseups()
    {
        _closeups.SetActive(true);
        _closeupIndex = 0;
        EnableCurrentCloseup();
    }
    public void HideCloseups()
    {
        _closeups.SetActive(false);
    }
    public void EnableCurrentCloseup()
    {
        if(_closeupIndex == _maxCloseupIndex)
        {
            HideCloseups();
        }
        else
        {
            _closeupIndex++;
        }

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
    }
}
