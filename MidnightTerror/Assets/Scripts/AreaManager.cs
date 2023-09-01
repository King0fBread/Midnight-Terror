using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    [SerializeField] private List<Area> _areasList;

    [SerializeField] private UIManager _uiManager;

    //array of area comopnents for referencing the areas

    [Serializable]
    private struct Area
    {
        public int horizontalAreaId;
        public int verticalAreaId;
        public AreaStatus status;
    }
    //set through buttons
    private int _currentAreaCodeHorizontal;
    private int _currentAreaCodeVertical;

    private void Start()
    {
        _currentAreaCodeHorizontal = 2;
        _currentAreaCodeVertical = 0;
        DisplayCurrentArea();
    }

    private void DisplayCurrentArea()
    {
        foreach(Area area in _areasList)
        {
            if(area.horizontalAreaId == _currentAreaCodeHorizontal &&
                area.verticalAreaId == _currentAreaCodeVertical)
            {
                _camera.transform.position = area.status.GetCameraTransform().position;
                _uiManager.DisplayDirectionButtons(area.status); 

                break;
            }
        }
    }

    public void ChangeDirectionToLeft()
    {
        _currentAreaCodeHorizontal -= 1;
        DisplayCurrentArea();
    }
    public void ChangeDirectionToRight()
    {
        _currentAreaCodeHorizontal += 1;
        DisplayCurrentArea(); 
    }
    public void ChangeDirectionToTop()
    {
        _currentAreaCodeVertical += 1;
        DisplayCurrentArea();
    }
    public void ChangeDirectionToBotton()
    {
        _currentAreaCodeVertical -= 1;
        DisplayCurrentArea();
    }
}
