using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float speed = .1f;

    float fistYPos;
    float fistXPos;

    private void Awake()
    {
        fistXPos = transform.position.x;
        fistYPos = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = target.position;
        transform.position = new Vector2(fistXPos - pos.x/speed, fistYPos-(pos.y/speed/4));


    }

    void FixedUpdate()
    {
        //Vector3 pos = new Vector3(traget.transform.position.x, 0, 0);

        ////transform.position = Vector3.Lerp(transform.position, -pos,Time.deltaTime * moveAmount);
        //transform.position = 

    }
}
