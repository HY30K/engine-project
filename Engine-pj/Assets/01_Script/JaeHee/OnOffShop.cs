using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffShop : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] GameObject shopPannel;
    [SerializeField] AudioSource open;
    [SerializeField] AudioSource close;

    public void ShopOpen()
    {
        ui.SetActive(false);
        shopPannel.SetActive(true);
        open.Play();
    }

    public void ShopClose()
    {
        ui.SetActive(true);
        shopPannel.SetActive(false);
        close.Play();
    }
}
