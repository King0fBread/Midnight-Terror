using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] private List<Area> _areasList;

    [Serializable]
    private struct Area
    {
        public int _horizontalAreaId;
        public int _verticalAreaId;
        public AreaStatus _status;
    }
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
