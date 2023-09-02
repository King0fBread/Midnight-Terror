using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _itemShowcaseImageSlot;
    //TODO get image slot through child
    private bool _isOccupied = false;
    //if not occupied - place in an item after picking up

    public void PlaceItemInSlot(Sprite itemSprite)
    {
        _itemShowcaseImageSlot.sprite = itemSprite;
        _isOccupied = true;
    }
    public void ClearSlot(Sprite defaultItemSprite)
    {
        _itemShowcaseImageSlot.sprite = defaultItemSprite;
        _isOccupied = false;
    }
}
