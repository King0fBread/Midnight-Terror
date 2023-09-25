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
    }
    private void Awake()
    {
        
    }
}
