using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMain : MonoBehaviour
{
    Vector3 firstPos;

    private bool waiting = false;
    public bool canTp = false;
    [SerializeField] GameObject prefabs;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            firstPos = transform.position;
            StartCoroutine(DelayTime());
        }
        if (canTp)
        {
            transform.position = new Vector3(6, -2, 0);
            canTp = false;
        }
    }

    IEnumerator DelayTime()
    {
        GameObject Effect = Instantiate(prefabs, transform.position, Quaternion.identity);

        waiting = true;
        yield return new WaitForSeconds(3f);

        if(firstPos == transform.position)
        {
            canTp = true;
        }

        waiting = false;

        if (firstPos != transform.position)
        {
            Destroy(Effect);
            StopCoroutine("DelayTime");
        }
        Destroy(Effect);
    }
}