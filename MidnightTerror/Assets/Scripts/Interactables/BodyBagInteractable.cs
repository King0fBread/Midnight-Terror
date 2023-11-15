using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBagInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _armWithItemObject;
    private int _currentBagState = 0;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void TryExecuteInteraction()
    {
        switch (_currentBagState)
        {
            case 0:
                if (InventoryManager.instance.TryToFindAndUseItem("OldKnife"))
                {
                    _animator.CrossFade("BagFloatingIdleFar", 0, 0);
                    _currentBagState++;
                }
                break;
            case 1:
                if (InventoryManager.instance.TryToFindAndUseItem("Rope"))
                {
                    _animator.CrossFade("BagFloatingIdleClose", 0, 0);
                    _currentBagState++;
                }
                break;
            case 2:
                if (InventoryManager.instance.TryToFindAndUseItem("Boxcutter"))
                {
                    _armWithItemObject.SetActive(true);
                    _currentBagState++;
                }
                break;
        }
    }
}
