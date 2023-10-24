using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class ForestAreaMovementManager : MonoBehaviour
{
    [SerializeField] private Transform[] _forestCameraTransforms;
    private int _currentForestAreaID = 0;
    private int _maxForestAreaID;

    private Camera _playerCamera;
    private void Awake()
    {
        _maxForestAreaID = _forestCameraTransforms.Length;
    }

    public void MoveToFirstForestArea(Camera playerCam)
    {
        _playerCamera = playerCam;
        
    }
    private void MoveToNextForestArea()
    {
        _playerCamera.transform.position = _forestCameraTransforms[_currentForestAreaID].position;
        _currentForestAreaID++;
    }
}
