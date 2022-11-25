using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkParticle : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        transform.position = player.transform.position;
    }
}
