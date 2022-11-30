using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeboss_Setactive : MonoBehaviour
{
    [SerializeField]
    GameObject Boss_Slime;
    [SerializeField]
    AudioSource BossFight, DungeonSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Boss_Slime.SetActive(true);
            BossFight.Play();
            DungeonSound.Stop();
        }
    }
}
