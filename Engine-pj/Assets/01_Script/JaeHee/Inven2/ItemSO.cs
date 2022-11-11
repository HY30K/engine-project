using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SEH00N
{
    [CreateAssetMenu(fileName = "ItemSO")]
    public class ItemSO : ScriptableObject 
    {
        [SerializeField] string itemName;
        public string ItemName => itemName;

        [SerializeField] Sprite itemImage;
        public Sprite ItemImage => itemImage;    

        [SerializeField] int stackCount;
        public int StackCount => stackCount;
    }
}
