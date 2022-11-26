using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Skill_Shoot : MonoBehaviour
{
    Transform Boss;
    GameObject player;
    float scale = 0.1f;
    float rotz = 0;
    Vector3 dir;
    float speed = 10;
    bool Moving = false;
    float destroytime = 6;
    int goingx;
    private void Awake()
    {

        Boss = GetComponentInParent<Transform>();
        player = GameObject.FindWithTag("Player");
    }
    private void Start()
    {
        if (Boss.transform.position.x <= player.transform.position.x)
        {
            dir = Vector3.right;
            goingx = 1;
        }
        else if (Boss.transform.position.x > player.transform.position.x)
        {
            dir = Vector3.left;
            goingx = -1;
        }
        transform.position = new Vector2(Boss.position.x, player.transform.position.y + Random.Range(0.5f, 2.5f));
        StartCoroutine(Destroytime());
    }
    void Update()
    {
        StartCoroutine(Starting());
        if (Moving) transform.position += dir * Time.deltaTime * speed;

    }

    IEnumerator Starting()
    {
        StartCoroutine(StartSpin());
        yield return new WaitForSeconds(2.5f);
        Moving = true;
    }
    IEnumerator StartSpin()
    {
        rotz -= 1.2f;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotz);
        if (scale < 1)
        {
            transform.localScale = new(scale / 4, scale / 4, 1);
            scale += 0.01f;
        }
        yield return new WaitForSeconds(Time.deltaTime);
        rotz -= 1.2f;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotz);
    }
    IEnumerator Destroytime()
    {
        yield return new WaitForSeconds(destroytime);
        Destroy(gameObject);
    }
}
