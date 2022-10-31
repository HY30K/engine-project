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
    bool _isHItting = false;
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
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Define.MainCam.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            hit = Physics2D.Raycast(transform.position,(mousePos-transform.position), raycastDistance,layer);
            
            Debug.DrawRay(transform.position, (mousePos - transform.position), Color.red, 0.5f);
            if (hit && !_isHItting)
            {
                _isHItting = true;
                StartCoroutine("HitMineral");
                Debug.Log("HIt");
                //hit.transform.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isHItting = false;
            StopCoroutine("HitMineral");
            //hit = null;
        }
    }

    IEnumerator HitMineral()
    {
        yield return new WaitForSeconds(1f);
        while (hit)
        {
            hit.collider.gameObject.GetComponent<MineralScript>().hp -= 1;// 1부분을 플레이어 곡괭이의 데미지로 바꿔줘야함;
            Debug.Log($"광석 이름 : {hit.collider.gameObject.GetComponent<MineralScript>().MineralType}, hp : { hit.collider.gameObject.GetComponent<MineralScript>().hp}");
            yield return new WaitForSeconds(0.5f);                                                              // 
        }
    }
}
