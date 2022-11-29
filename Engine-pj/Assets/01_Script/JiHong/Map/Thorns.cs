using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    Vector2 Startpos;
    public LayerMask layerMask;

    private void Awake()
    {
        Startpos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = Startpos + new Vector2(-3, 5);
            print("°¡½Ã");
        }
        else if (!(collision.gameObject.layer == layerMask))
        {
            collision.transform.position = new Vector2(transform.position.x + 2, transform.position.y + 5);
        }
    }
}
