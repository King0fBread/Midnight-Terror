using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image _itemShowcaseImageSlot;
    private bool _isOccupied = false;
    //if not occupied - place in an item after picking up
    private void Awake()
    {
        _itemShowcaseImageSlot = transform.GetChild(0).GetComponent<Image>();
    }
    public bool GetSlotOccupiedState()
    {
        return _isOccupied;
    }

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
    public string GetItemByName()
    {
        return _itemShowcaseImageSlot.sprite.name;
    }
}
