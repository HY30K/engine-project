using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple GameManager is running");
        }
        instance = this;
    }
}
