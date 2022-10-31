using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tp : MonoBehaviour
{
    private BoxCollider2D collider2D;
    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && gameObject.tag == "ToDg")
            SceneManager.LoadScene("Main");
        else if (other.transform.tag == "Player" && gameObject.tag == "ToMine")
            SceneManager.LoadScene("JiHong");
    }
}
