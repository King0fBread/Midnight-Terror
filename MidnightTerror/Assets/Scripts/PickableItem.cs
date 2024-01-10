using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private Sprite _sprite;
    private bool _isPickedUp = false;
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }
    public void PlaceItemInInventory()
    {
        _isPickedUp = InventoryManager.instance.TryPlaceItemInFreeSlot(_sprite);

        if(_isPickedUp)
            Destroy(gameObject);
    }
}
