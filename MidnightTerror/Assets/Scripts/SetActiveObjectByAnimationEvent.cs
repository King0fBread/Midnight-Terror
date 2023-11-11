using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObjectByAnimationEvent : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private bool _shouldBeActive;
    public void SetActiveTarget()
    {
        _targetObject.SetActive(_shouldBeActive);
    }
}
