using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Collider : MonoBehaviour
{
    float ct;
    private void Update()
    {
        ct+=Time.deltaTime;
        if (ct > 3f)
        {
            ct = 0;
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("ºÒ¸ÂÀ½");
        }
        if (collision.gameObject.name.Contains("Demon_Boss"))
        {
            gameObject.SetActive(false);
        }
    }
}
