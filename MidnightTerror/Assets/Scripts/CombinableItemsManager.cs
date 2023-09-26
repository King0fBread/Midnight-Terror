using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinableItemsManager : MonoBehaviour
{
    [SerializeField] private List<Combinable> _combinables = new List<Combinable>();

    [System.Serializable]
    public class Combinable
    {
        public Sprite _finalItem;

        public Sprite _firstCombinableItem;
        public Sprite _secondCombinableItem;

        private InventorySlot _firstSlotWithACombinable;
        private InventorySlot _secondSlotWithACombinable;

        private bool _firstSlotOccupied = false;
        private bool _secondSlotOccupied = false;

        public bool CheckIfSpriteIsCombinable(Sprite sprite)
        {
            return sprite == _firstCombinableItem || sprite == _secondCombinableItem;
        }
        public void PopulateAvailableSlot(InventorySlot slot)
        {
            if (!_firstSlotOccupied)
            {
                _firstSlotWithACombinable = slot;
                _firstSlotOccupied = true;
            }
            else if (!_secondSlotOccupied)
            {
                _secondSlotWithACombinable = slot;
                _secondSlotOccupied = true;
            }
            //enable merging button UI
        }
    }
    public void CheckIfSlotHasCombinable(InventorySlot slot)
    {
        //foreach Combinable loop, if slot sprite == required sprite, fill 1 combinable slot etc. if 2 filled == place new item in inventory and remove combinables
        foreach(Combinable combinable in _combinables)
        {
            if (combinable.CheckIfSpriteIsCombinable(slot.GetItemBySprite()))
            {
                combinable.PopulateAvailableSlot(slot);
            }
        }
    }
}
