using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveCloseupInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _graveBasic;
    [SerializeField] private GameObject _graveDugUp;
    [SerializeField] private string _requiredInteractionItem;

    [SerializeField] private BoxCollider2D _graveInitialCollider;
    [SerializeField] private BoxCollider2D _graveDiggingCollider;
    private void Awake()
    {
        _graveDiggingCollider.enabled = false;
        _graveInitialCollider.enabled = true;
    }

    public void TryExecuteInteraction()
    {
        print("grave inetarction");
        if (!_graveBasic.activeSelf)
        {
            _graveBasic.SetActive(true);
            _graveInitialCollider.enabled = false;
            _graveDiggingCollider.enabled = true;
        }
        else if (InventoryManager.instance.TryToFindAndUseItem(_requiredInteractionItem))
        {
            _graveDugUp.SetActive(true);
            _graveDiggingCollider.enabled = false;
        }
    }
}
