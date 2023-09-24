using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearItemInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _batteriesPickable;
    [SerializeField] private string _requiredItem;

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void TryExecuteInteraction()
    {
        if (InventoryManager.instance.TryToFindAndUseItem(_requiredItem))
        {
            _animator.CrossFade("BearItemBroken", 0, 0);
            _batteriesPickable.SetActive(true);
        }
    }
}
