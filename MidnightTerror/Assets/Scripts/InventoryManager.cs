using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Sprite _defalutSlotSprite;

    [SerializeField] private InventorySlot[] _inventorySlots;

    public static InventoryManager instance { get { return _instance; } }
    private static InventoryManager _instance;

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

        foreach (InventorySlot slot in _inventorySlots)
        {
            slot.ClearSlot(_defalutSlotSprite);
        }
    }

    public bool TryToFindAndUseItem(string requiredItem)
    {
        foreach(InventorySlot slot in _inventorySlots)
        {
            if(slot.GetItemByName() == requiredItem)
            {
                slot.ClearSlot(_defalutSlotSprite);
                return true;
            }
        }
        return false;
    }
    public bool TryPlaceItemInFreeSlot(Sprite sprite)
    {
        foreach(InventorySlot slot in _inventorySlots)
        {
            if(slot.GetSlotOccupiedState() == false)
            {
                slot.PlaceItemInSlot(sprite);
                return true;
            }
        }
        return false;
    }

}
