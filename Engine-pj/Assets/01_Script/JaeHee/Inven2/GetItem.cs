using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            item = collision.GetComponent<Item>();
            Debug.Log(collision.name);
            Inventory.instance.AddItem(item);
            item.gameObject.SetActive(false);// Ç®¸µ
        }
    }
}
