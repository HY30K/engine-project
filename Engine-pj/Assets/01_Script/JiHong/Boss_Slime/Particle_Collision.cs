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
        if (other.gameObject.CompareTag("Player"))
        {
            print("ºÒµ¢ÀÌ¸ÂÀ½");
        }
        int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);
        StartCoroutine(Summon_FO(numCollisionEvents));
    }
    IEnumerator Summon_FO(int numCollisionEvents)
    {
        if (i < numCollisionEvents)
        {
            Fireobejcts.transform.position = collisionEvents[i].intersection;
            Fireobejcts.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            Fireobejcts.SetActive(false);
            i++;
        }
        i = 0;
    }
}
