using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemDatebase : MonoBehaviour
{
    public static ItemDatebase instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemList = new();

    public GameObject fieldItemPrefabs;


    public void SpawnItem(Vector2 pos)
    {
        GameObject go = Instantiate(fieldItemPrefabs, pos, Quaternion.identity);
        go.GetComponent<FieldItems>().SetItem(itemList[Random.Range(0, itemList.Count)]);
    }

    public void SpawnItem(Vector2 pos, Item item)
    {
        GameObject go = Instantiate(fieldItemPrefabs, pos, Quaternion.identity);
        go.GetComponent<FieldItems>().SetItem(item);
    }
}
