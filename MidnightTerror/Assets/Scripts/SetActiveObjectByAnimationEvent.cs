using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetActiveObjectByAnimationEvent : MonoBehaviour
{
    public ObjectActivationStatePair[] objectActivationStatePairs;
    [System.Serializable] public class ObjectActivationStatePair
    {
        public GameObject targetObject;
        public bool shouldBeActive;
    }
    public void SetTargetsActive()
    {
        foreach (var pair in objectActivationStatePairs)
        {
            pair.targetObject.SetActive(pair.shouldBeActive);

        }
    }
    public void DestroyTargets()
    {
        foreach (var pair in objectActivationStatePairs) 
        {
            Destroy(pair.targetObject);
        }
    }
}
