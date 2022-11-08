using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffShop : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameObject shopPannel;

    public void ShopOpen()
    {
        ui.SetActive(false);
        shopPannel.SetActive(true);
    }

    public void ShopClose()
    {
        ui.SetActive(true);
        shopPannel.SetActive(false);
    }
}
