using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private void Start()
    {
        ItemDatebase.instance.SpawnItem(transform.position);
    }
}
