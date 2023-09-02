using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Sprite _defalutSlotSprite;

    [SerializeField] private InventorySlot[] _inventorySlots;
    void Start()
    {
        foreach (InventorySlot slot in _inventorySlots)
        {
            slot.ClearSlot(_defalutSlotSprite);
        }
    }

}
