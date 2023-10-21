using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class EndingMovementManager : MonoBehaviour
{
    [SerializeField] private Transform _endingCameraTransform;

    [SerializeField] private GameObject _lanternAreaObject;
    [SerializeField] private GameObject _gateAreaObject;

    [SerializeField] private GameObject _baseMovementUI;
    [SerializeField] private GameObject _endingMovementUI;

    [SerializeField] private float _imageSizeIncreasePerStep;
    [SerializeField] private int _totalAmountOfSteps;

    [SerializeField] private Button _forwardButton;
    [SerializeField] private Button _leftButton;

    private Camera _camera;

    private GameObject _currentArea;
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

        _forwardButton.onClick.AddListener(MoveForward);
        _leftButton.onClick.AddListener(MoveLeft);
    }
    public void MoveToEndingArea()
    {
        _camera.transform.position = _endingCameraTransform.position;

        _currentArea = _lanternAreaObject;

        _baseMovementUI.SetActive(false);
        _endingMovementUI.SetActive(true);
    }
    private void MoveForward()
    {
        if(_currentStep < _totalAmountOfSteps)
        {
            if(_currentStep < _totalAmountOfSteps)
            {
                _currentStep++;

                _currentArea.transform.localScale += new Vector3(_imageSizeIncreasePerStep, _imageSizeIncreasePerStep, 0);
                if(_currentStep == _totalAmountOfSteps - 1)
                {
                    _endingMovementUI.SetActive(false);
                    //enable a ghost with an item?
                }


            }
        }
    }
    private void MoveLeft()
    {

    }
    public void EnableMovingLeft()
    {
        //_forwardButton.onClick.
    }

}
