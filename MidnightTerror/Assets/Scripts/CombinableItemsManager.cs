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


    }
    public void CheckIfSlotHasCombinable(InventorySlot slot)
    {
        //foreach Combinable loop, if slot sprite == required sprite, fill 1 combinable slot etc. if 2 filled == place new item in inventory and remove combinables
    }
}
