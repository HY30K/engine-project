using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Collider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("ºÒ¸ÂÀ½");
        }
    }
}
