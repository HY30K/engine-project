using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MiningParticle : PoolAbleMono
{
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void DestroyMiningParticle()
    {
        PoolManager.Instance.Push(this);
    }

    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
        //_audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Init()
    {

    }
}