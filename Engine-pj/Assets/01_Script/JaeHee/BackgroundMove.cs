using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Transform traget;
    [SerializeField] private float moveAmount = 2;

    void FixedUpdate()
    {
        Vector3 pos = new Vector3(traget.transform.position.x, 0, 0);

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * moveAmount);
    }
}
