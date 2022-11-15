using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public GameObject BackGround1;
    public GameObject BackGround2;
    public GameObject BackGround3;
    public GameObject BackGround4;
    public GameObject BackGround5;

    public int speed1 = 5;
    public int speed2 = 4;
    public int speed3 = 3;
    public int speed4 = 2;
    public int speed5 = 1;

    Transform _player;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
            

    }
}
