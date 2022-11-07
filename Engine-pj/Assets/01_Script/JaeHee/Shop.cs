using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInterectable
{
    [SerializeField] GameObject panel;

    [SerializeField] GameObject onOffButton;

    public void Interect()
    {
        if (Physics2D.OverlapBox(transform.position, Vector2.one * 5, 0, Define.Player))
        {
            onOffButton.SetActive(true);
        }
        else
        {
            onOffButton.SetActive(false);
        }
    }
}
