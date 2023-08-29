using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaStatus : MonoBehaviour
{
    [SerializeField] private Transform _areaCameraTransform;
    [SerializeField] private bool[] _walkableDirectionsClockwiseFromTop = new bool[4];
    public Transform GetCameraTransform()
    {
        return _areaCameraTransform;
    }
    public bool[] GetDirectionsArray()
    {
        return _walkableDirectionsClockwiseFromTop;
    }
}
