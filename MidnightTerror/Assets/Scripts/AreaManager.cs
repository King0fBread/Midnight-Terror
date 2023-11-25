using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] private GameObject _camera;

    [SerializeField] private List<Area> _areasList;

    [SerializeField] private UIManager _uiManager;

    [SerializeField] private TransitionScreenAlphaControl _transitionScreenAlphaControl;

    //array of area comopnents for referencing the areas

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

    private void Start()
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
                StartCoroutine(MoveToAreaCoroutine(area));
                break;
            }
        }
    }
    private IEnumerator MoveToAreaCoroutine(Area area)
    {
        _transitionScreenAlphaControl.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        _camera.transform.position = area.status.GetCameraTransform().position;
        _uiManager.DisplayDirectionButtons(area.status);

        CheckAreaForFunctionalityAndExecute(area.status);
    }
    private void CheckAreaForFunctionalityAndExecute(AreaStatus area)
    {
        IFunctionalArea areaFunctionality;
        if(area.gameObject.TryGetComponent(out areaFunctionality))
        {
            areaFunctionality.ExecuteMechanicOnEntrance();
        }
    }
    private void PlayRandomWalkingSound()
    {
        int randomID = UnityEngine.Random.Range(0, 2);
        Array enumValues = Enum.GetValues(typeof(SoundsManager.Sounds));
        SoundsManager.Sounds sound = (SoundsManager.Sounds)enumValues.GetValue(randomID);

        SoundsManager.instance.PlaySound(sound);
    }

    public void ChangeDirectionToLeft()
    {
        _currentAreaCodeHorizontal -= 1;
        DisplayCurrentArea();
        PlayRandomWalkingSound();
    }
    public void ChangeDirectionToRight()
    {
        _currentAreaCodeHorizontal += 1;
        DisplayCurrentArea();
        PlayRandomWalkingSound();
    }
    public void ChangeDirectionToTop()
    {
        _currentAreaCodeVertical += 1;
        DisplayCurrentArea();
        PlayRandomWalkingSound();
    }
    public void ChangeDirectionToBotton()
    {
        _currentAreaCodeVertical -= 1;
        DisplayCurrentArea();
        PlayRandomWalkingSound();
    }
    public void SetAreaCodesAndMoveToArea(int horizontalCode, int verticalCode)
    {
        _currentAreaCodeHorizontal = horizontalCode;
        _currentAreaCodeVertical = verticalCode;

        DisplayCurrentArea();
    }
}
