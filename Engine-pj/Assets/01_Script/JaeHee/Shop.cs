using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInterectable
{
    [SerializeField] GameObject panel;

    [SerializeField] GameObject onOffButton;

    private void Awake()
    {
        onOffButton.transform.position = new Vector3(transform.position.x,transform.position.y + 1);
    }

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
