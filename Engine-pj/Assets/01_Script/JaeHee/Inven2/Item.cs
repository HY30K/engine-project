using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SEH00N
{
    public class Item : MonoBehaviour
    {
        [SerializeField] ItemSO itemData;
        public ItemSO ItemData => itemData;
    }
}
