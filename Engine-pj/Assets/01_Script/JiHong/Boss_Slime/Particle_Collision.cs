using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Collision : MonoBehaviour
{
    ParticleSystem ps;
    [SerializeField]
    GameObject Fireobejcts;
    int i=0;
    [SerializeField]
    List<ParticleCollisionEvent> collisionEvents;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);
        if (i < numCollisionEvents)
        {
            StartCoroutine(Summon_FO(numCollisionEvents));
            if (other.gameObject.CompareTag("Player"))
            {
                print("ºÒµ¢ÀÌ¸ÂÀ½");
            }
        }
        else
        {
            i = 0;
            StartCoroutine(Summon_FO(numCollisionEvents));
        }

    }
    IEnumerator Summon_FO(int numCollisionEvents)
    {
        if (i < numCollisionEvents)
        {
            Fireobejcts.transform.position = collisionEvents[i].intersection;
            Fireobejcts.SetActive(true);
            yield return null;//new WaitForSeconds(1.5f);
            //Fireobejcts.SetActive(false);
            i++;
        }
        else
        {
            i = 0;
            StartCoroutine(Summon_FO(numCollisionEvents));
        }
    }
}
