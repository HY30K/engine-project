using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpandDownObject : MonoBehaviour
{
    float high_pos;
    float low_pos;
    public bool upper;
    public bool lower;
    bool execute = false;
    Vector3 dir;
    float speed = 5;
    [SerializeField]
    float updowngap;
    private void Start()
    {
        high_pos = transform.position.y + updowngap;
        low_pos = transform.position.y;
    }
    void Update()
    {
        if (transform.position.y >= high_pos - 0.1f)
        {
            lower = false;
            upper = true;
        }
        else if (transform.position.y <= low_pos + 0.1f)
        {
            lower = true;
            upper = false;
        }
        if (execute)
        {
            Executer();
        }
        if (lower && transform.position.y < high_pos && !upper)
        {
            dir = Vector3.up;
        }
        else if (!lower && transform.position.y > low_pos && upper)
        {
            dir = Vector3.down;
        }
    }
    void Executer()
    {
        transform.position += dir * speed * Time.deltaTime;
        if (dir == Vector3.down)
        {
            if (transform.position.y < low_pos + 0.1f)
            {
                lower = true; upper = false; execute = false;
            }
        }
        else if (dir == Vector3.up)
        {
            if (transform.position.y > high_pos - 0.1f)
            {
                upper = true; lower = false; execute = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(this.transform);
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("Player"))
        {
            execute = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("Player"))
        {
            execute = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}