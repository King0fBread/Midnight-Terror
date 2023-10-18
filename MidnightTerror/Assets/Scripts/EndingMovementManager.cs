using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Properties;
using UnityEngine;

public class EndingMovementManager : MonoBehaviour
{
    [SerializeField] private Transform _endingCameraTransform;

    [SerializeField] private GameObject _areaObject;

    [SerializeField] private GameObject _baseMovementUI;
    [SerializeField] private GameObject _endingMovementUI;

    [SerializeField] private float _imageSizeIncreasePerStep;
    [SerializeField] private int _totalAmountOfSteps;

    private Camera _camera;

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

        _camera = Camera.main;
    }
    public void MoveToEndingArea()
    {
        _camera.transform.position = _endingCameraTransform.position;

        _baseMovementUI.SetActive(false);
        _endingMovementUI.SetActive(true);
    }
    public void MoveForward()
    {
        if(_currentStep < _totalAmountOfSteps)
        {
            if(_currentStep < _totalAmountOfSteps)
            {
                _currentStep++;

                _areaObject.transform.localScale += new Vector3(_imageSizeIncreasePerStep, _imageSizeIncreasePerStep, 0);
                if(_currentStep == _totalAmountOfSteps - 1)
                {
                    _endingMovementUI.SetActive(false);
                    //enable a ghost with an item?
                }


            }
        }
    }

}
