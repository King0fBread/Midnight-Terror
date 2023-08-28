using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    [SerializeField] private List<Area> _areasList;

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
    void Start()
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
                //call ui manager for buttons
                break;
            }
        }
    }

    public void ChangeDirectionToLeft()
    {

    }
    public void ChangeDirectionToRight()
    {

    }
    public void ChangeDirectionToTop()
    {

    }
    public void ChangeDirectionToBotton()
    {

    }
}
