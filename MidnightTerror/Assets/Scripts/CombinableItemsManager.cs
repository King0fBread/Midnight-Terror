using System.Collections.Generic;
using UnityEngine;

public class CombinableItemsManager : MonoBehaviour
{
    [SerializeField] private List<Combinable> _combinables = new List<Combinable>();
    [SerializeField] private GameObject _combineButton;
    [SerializeField] private Combinable _availableCombinable;

    [System.Serializable]
    public class Combinable
    {
        public Sprite _finalItem;

        public Sprite _firstCombinableItem;
        public Sprite _secondCombinableItem;

        private InventorySlot _firstSlotWithACombinable;
        private InventorySlot _secondSlotWithACombinable;

        private bool _firstSlotOccupied = false;

        public bool CheckIfSpriteIsCombinable(Sprite sprite)
        {
            return sprite == _firstCombinableItem || sprite == _secondCombinableItem;
        }
        public Combinable PopulateAvailableSlot(InventorySlot slot)
        {
            if (!_firstSlotOccupied)
            {
                _firstSlotWithACombinable = slot;
                _firstSlotOccupied = true;
                return null;
            }
            else
            {
                _secondSlotWithACombinable = slot;
                return this;
            }
            
        }
        public InventorySlot GetFirstSlot()
        {
            return _firstSlotWithACombinable;
        }
        public InventorySlot GetSecondSlot()
        {
            return _secondSlotWithACombinable;
        }
        public void ClearCoombinable()
        {
            _firstSlotWithACombinable = null;
            _secondSlotWithACombinable = null;

            _firstSlotOccupied = false;
        }
    }
    public void CheckIfSlotHasCombinable(InventorySlot slot)
    {
        foreach(Combinable combinable in _combinables)
        {
            if (combinable.CheckIfSpriteIsCombinable(slot.GetItemBySprite()))
            {
                _availableCombinable = combinable.PopulateAvailableSlot(slot);

                if(_availableCombinable != null)
                {
                    _combineButton.SetActive(true);
                }
            }
        }
    }
    public void CombineItems()
    {
        _combineButton.SetActive(false);

        _availableCombinable.GetFirstSlot().ClearSlot(InventoryManager.instance.defalutSlotSprite);
        _availableCombinable.GetSecondSlot().ClearSlot(InventoryManager.instance.defalutSlotSprite);

        _availableCombinable.GetFirstSlot().PlaceItemInSlot(_availableCombinable._finalItem);

        _availableCombinable.ClearCoombinable();
    }
}
