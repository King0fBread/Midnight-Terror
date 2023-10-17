using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Properties;
using UnityEngine;

public class EndingMovementManager : MonoBehaviour
{
    [SerializeField] private float _imageSizeIncreasePerStep;
    [SerializeField] private int _totalAmountOfSteps;

    [SerializeField] private GameObject _baseMovementUI;
    [SerializeField] private GameObject _endingMovementUI;

    private int _currentStep = 0;

    public static EndingMovementManager instance { get { return _instance; } }
    private static EndingMovementManager _instance;

    private void Start()
    {
        if(_instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void MoveToEndingArea()
    {

    }

}
