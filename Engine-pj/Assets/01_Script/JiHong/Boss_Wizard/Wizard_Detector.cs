using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Detector : MonoBehaviour
{
    [SerializeField]
    LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Detecting()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, 15, layer);
        if (collision != null)
        {
            //Target = collision.transform;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 15);
    }
}
