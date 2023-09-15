using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveCloseupInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _graveBasic;
    [SerializeField] private GameObject _graveDugUp;
    [SerializeField] private string _requiredInteractionItem;

    public void TryExecuteInteraction()
    {
        print("grave inetarction");
        if (!_graveBasic.activeSelf)
        {
            _graveBasic.SetActive(true);
        }
        else if (InventoryManager.instance.TryToFindAndUseItem(_requiredInteractionItem))
        {
            _graveDugUp.SetActive(true);
        }
    }
}
