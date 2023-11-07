using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class ForestAreaMovementManager : MonoBehaviour
{
    [SerializeField] private GameObject _forestMovementUI;
    [SerializeField] private GameObject _forestGhostObject;
    [SerializeField] private Transform[] _forestCameraTransforms;
    [SerializeField] private Button[] _forestMovementButtons;
    private int _currentForestAreaID;
    private int _maxForestAreaID;

    private Camera _playerCamera;
    private void Awake()
    {
        _maxForestAreaID = _forestCameraTransforms.Length;

        foreach(Button button in _forestMovementButtons)
        {
            button.onClick.AddListener(MoveToNextForestArea);
        }

        _forestMovementUI.SetActive(false);
    }

    public void MoveToFirstForestArea(Camera playerCam)
    {
        _forestMovementUI.SetActive(true);

        _playerCamera = playerCam;
        _currentForestAreaID = 0;

        MoveToNextForestArea();
        
    }
    private void MoveToNextForestArea()
    {

        _playerCamera.transform.position = _forestCameraTransforms[_currentForestAreaID].position;
        _currentForestAreaID++;

        if (_currentForestAreaID == _maxForestAreaID)
        {
            foreach (Button button in _forestMovementButtons)
            {
                button.onClick.RemoveListener(MoveToNextForestArea);
            }

            _forestMovementUI.SetActive(false);
            _forestGhostObject.SetActive(true);
        }
    }
}
