using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Item currentItem = null;
    public Item CurrentItem => currentItem;

    private int currentStackCount = 0;
    public int CurrentStackCount => currentStackCount;

    private TextMeshProUGUI stackText = null;
    private Image image = null;

    private void Awake()
    {
        stackText = GetComponentInChildren<TextMeshProUGUI>();
        image = transform.GetChild(1).GetComponent<Image>();
        image.sprite = currentItem.ItemData.ItemImage;
    }

    public void AddItem()
    {
        currentStackCount++;
        stackText.text = $"{currentStackCount}";
    }

    public void RemoveItem()
    {
        if (currentStackCount >= 0)
        {
            currentStackCount--;
            stackText.text = $"{currentStackCount}";
        }
    }

    public void SetItem(Item item, int count = 1)
    {
        currentItem = item;
        currentStackCount = count;

        image.sprite = currentItem.ItemData.ItemImage;

        stackText.text = $"{currentStackCount}";
    }
}
