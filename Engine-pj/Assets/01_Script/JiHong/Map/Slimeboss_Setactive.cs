using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeboss_Setactive : MonoBehaviour
{
    [SerializeField]
    GameObject Boss_Slime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Boss_Slime.SetActive(true);
    }
}
