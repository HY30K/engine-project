using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_atk_collider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("이걸맞네;");
        }
    }
}
