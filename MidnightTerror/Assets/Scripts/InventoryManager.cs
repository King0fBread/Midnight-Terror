using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Sprite defalutSlotSprite;

    [SerializeField] private InventorySlot[] _inventorySlots;

    [SerializeField] private CombinableItemsManager _combinableItemsManager;

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
            slot.ClearSlot(defalutSlotSprite);
        }
    }

    public bool TryToFindAndUseItem(string requiredItem)
    {
        foreach(InventorySlot slot in _inventorySlots)
        {
            if(slot.GetItemByName() == requiredItem)
            {
                slot.ClearSlot(defalutSlotSprite);
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
                _combinableItemsManager.CheckIfSlotHasCombinable(slot);

                SoundsManager.instance.PlaySound(SoundsManager.Sounds.ItemPickup);

                return true;
            }
        }
        return false;
    }

}
