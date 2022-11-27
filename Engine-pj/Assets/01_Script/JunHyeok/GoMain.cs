using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMain : MonoBehaviour
{
    Vector3 firstPos;

    private bool waiting = false;
    [SerializeField] GameObject prefabs;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !waiting)
        {
            //firstPos = this.transform.position;
            StartCoroutine(DelayTime());
        }
    }

    IEnumerator DelayTime()
    {
        GameObject Effect = Instantiate(prefabs, transform.position, Quaternion.identity);

        waiting = true;
        yield return new WaitForSeconds(3f);
        waiting = false;


        if (Input.anyKeyDown)
        {
            StopCoroutine("DelayTime");
            Destroy(Effect);
        }

        transform.position = new Vector3(6, -2, 0);

        Destroy(Effect);

    }
}