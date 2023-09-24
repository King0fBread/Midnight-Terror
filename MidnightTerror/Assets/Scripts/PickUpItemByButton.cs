using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpItemByButton : MonoBehaviour
{
    [SerializeField] private Sprite _itemSprite;

    public void TryPickUpitem()
    {
        InventoryManager.instance.TryPlaceItemInFreeSlot(_itemSprite);
        Destroy(gameObject);
    }
}
