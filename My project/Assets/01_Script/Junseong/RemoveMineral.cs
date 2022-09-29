using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMineral : MonoBehaviour
{
    public float raycastDistance = 15f;
    CapsuleCollider2D _capCollider;
    Rigidbody2D _rigid;
    RaycastHit2D hit;
    Vector3 mousePos;
    public float speed = 5f;
    public LayerMask layer;
    
    private void Awake()
    {
         _rigid = GetComponent<Rigidbody2D>();
        _capCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        DoMining();
//        PlayerMove();
    }

    public void DoMining()// 플레이어에서 불러와줘야함
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Define.MainCam.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            hit = Physics2D.Raycast(transform.position,(mousePos-transform.position), raycastDistance,layer);
            
            Debug.DrawRay(transform.position, (mousePos - transform.position), Color.red, 0.5f);
            if (hit)
            {
                Debug.Log("HIt");
                hit.transform.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }

    }
    
    
}
