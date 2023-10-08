using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBagInteractable : MonoBehaviour, IInteractable
{
    private int _currentBagState = 0;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void TryExecuteInteraction()
    {
        if (InventoryManager.instance.TryToFindAndUseItem("OldKnife") && _currentBagState == 0)
        {
            _animator.CrossFade("BagFloatingIdleFar", 0, 0);

        }
        else
        {
            print("next state");
        }
        _currentBagState++;
    }
}
