using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("FieldItem"))
        {
            item = collision.transform.GetComponent<Item>();
            Inventory.instance.AddItem(item);
            item.gameObject.SetActive(false);// Ç®¸µ
        }
    }
}
