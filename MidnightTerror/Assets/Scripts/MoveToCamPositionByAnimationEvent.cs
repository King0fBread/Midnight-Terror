using UnityEngine;

public class MoveToCamPositionByAnimationEvent : MonoBehaviour
{
    [SerializeField] private Transform _newCameraTransform;
    private Camera _camera;
    private void OnEnable()
    {
        _camera = Camera.main;
    }
    public void MoveToCamLocation()
    {
        _camera.transform.position = _newCameraTransform.position;
    }
}
