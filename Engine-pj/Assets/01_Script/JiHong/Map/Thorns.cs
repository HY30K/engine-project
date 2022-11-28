using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    Vector2 Startpos = new Vector2(-172,1.5f);
    public LayerMask layerMask;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = Startpos;
        }
        else if (!(collision.gameObject.layer == layerMask))
        {
            collision.transform.position = new Vector2(transform.position.x + 2, transform.position.y + 5);
        }
    }
}
