using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return2Startpos : MonoBehaviour
{
    [SerializeField]
    Vector3 Startpos;
    private void Start()
    {
        Startpos = new Vector3(1, 2, 3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = Startpos;
    }
}
