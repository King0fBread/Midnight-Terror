using UnityEngine;
using UnityEngine.UI;

public class LanternAreaMovementManager : MonoBehaviour
{
    [SerializeField] private Transform _lanternAreaCameraTransform;

    [SerializeField] private GameObject _lanternAreaObject;

    [SerializeField] private GameObject _baseMovementUI;
    [SerializeField] private GameObject _lanternAreaMovementUI;

    [SerializeField] private GameObject _runText;

    [SerializeField] private float _imageSizeIncreasePerStep;
    [SerializeField] private int _totalAmountOfSteps;

    [SerializeField] private Button _forwardButton;
    [SerializeField] private Button _leftButton;

    [SerializeField] private Animator _ghostAnimator;

    [SerializeField] private ForestAreaMovementManager _forestManager;

    private Camera _camera;

    private int _currentStep = 0;

    public static LanternAreaMovementManager instance { get { return _instance; } }
    private static LanternAreaMovementManager _instance;

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

        _forwardButton.onClick.AddListener(MoveForwardByButton);
        _leftButton.onClick.AddListener(LeaveLanternAreaByLeftButton);

        _lanternAreaMovementUI.SetActive(false);
    }
    public void MoveToLanternArea()
    {
        _camera.transform.position = _lanternAreaCameraTransform.position;

        SoundsManager.instance.StopSoundManually(true);

        _baseMovementUI.SetActive(false);
        _lanternAreaMovementUI.SetActive(true);

        //can only move forward at first
        _leftButton.gameObject.SetActive(false);
    }
    private void MoveForwardByButton()
    {
        if(_currentStep < _totalAmountOfSteps)
        {
            _currentStep++;

            _lanternAreaObject.transform.localScale += new Vector3(_imageSizeIncreasePerStep, _imageSizeIncreasePerStep, 0);
            if (_currentStep == _totalAmountOfSteps)
            {
                _ghostAnimator.CrossFade("GhostSmilingActive", 0, 0);
            }
        }
    }
    private void LeaveLanternAreaByLeftButton()
    {
        _lanternAreaObject.SetActive(false);
        _lanternAreaMovementUI.SetActive(false);
        _runText.SetActive(true);

        _forestManager.MoveToFirstForestArea(_camera);

        SoundsManager.instance.PlaySound(SoundsManager.Sounds.AmbienceFinalForest);
    }
    public void EnableLeavingLanternArea()
    {
        _forwardButton.gameObject.SetActive(false);

        _leftButton.gameObject.SetActive(true);
    }

}
