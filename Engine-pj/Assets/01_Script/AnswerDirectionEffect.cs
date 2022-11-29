using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerDirectionEffect : MonoBehaviour
{
    public Transform player;
    public GameObject DirectionSignMine;
    public GameObject DirectionSignDungeon;
    BoxCollider2D boxCollider;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        //DirectionSignMine = GameObject.Find("SignActiveCheckCoolider").GetComponent<TextFadeInOut>();
        //DirectionSignDungeon = GameObject.Find("SignActiveCheckCoolider").GetComponent<TextFadeInOut>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DirectionSignDungeon.GetComponent<TextFadeInOut>().FadeIN();
            DirectionSignMine.GetComponent<TextFadeInOut>().FadeIN();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DirectionSignDungeon.GetComponent<TextFadeInOut>().FadeOUT();
            DirectionSignMine.GetComponent<TextFadeInOut>().FadeOUT();
        }
    }


    private void Update()
    {
        
            
            
    }
}
