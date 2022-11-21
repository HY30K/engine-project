using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Transform traget;
    public float speed = .1f;


    // Update is called once per frame
    void Update()
    {
        Vector2 pos = traget.position;
        transform.localPosition = new Vector2(pos.x/speed, -(pos.y/speed/4));


    }

    void FixedUpdate()
    {
        //Vector3 pos = new Vector3(traget.transform.position.x, 0, 0);

        ////transform.position = Vector3.Lerp(transform.position, -pos,Time.deltaTime * moveAmount);
        //transform.position = 

    }
}
