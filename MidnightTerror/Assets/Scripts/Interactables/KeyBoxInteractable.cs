using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoxInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string _requiredItem;
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    public void TryExecuteInteraction()
    {
        if (InventoryManager.instance.TryToFindAndUseItem(_requiredItem))
        {
            _boxCollider.enabled = false;
            _animator.CrossFade("KeyBoxOpened", 0, 0);
        }
        //change the scene layout for the ending
    }
}
