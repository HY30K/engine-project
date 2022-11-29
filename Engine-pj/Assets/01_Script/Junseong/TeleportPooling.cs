using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPooling : MonoBehaviour
{
    //public override void Init()
    //{
        
    //}

    //public void DestroyTp()
    //{
    //    PoolManager.Instance.Push(this);
    //}

    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
        //_audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
