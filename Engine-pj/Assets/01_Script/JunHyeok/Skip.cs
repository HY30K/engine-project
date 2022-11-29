using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    private void Awake()
    {
        Invoke("ChangeScene", 35);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
