using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

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
                //UI
                return this;
            }
            
        }
    }
    public void CheckIfSlotHasCombinable(InventorySlot slot)
    {
        foreach(Combinable combinable in _combinables)
        {
            if (combinable.CheckIfSpriteIsCombinable(slot.GetItemBySprite()))
            {
                _availableCombinable = combinable.PopulateAvailableSlot(slot);
            }
        }
    }
    public void CombineItems()
    {
        //place new item in inventory and remove combinables
    }
}
