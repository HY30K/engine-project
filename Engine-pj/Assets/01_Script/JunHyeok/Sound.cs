using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : AudioPlayer
{
    [SerializeField]
    private AudioClip _hitClip = null, _deathClip = null, _attackClip = null, _mineClip = null;


    public void PlayHitSound()
    {
        PlayClipWithVariablePitch(_hitClip);
    }

    public void PlayDeathSound()
    {
        PlayClip(_deathClip);
    }

    public void PlayAttackSound()
    {
        PlayClip(_attackClip);
    }

    public void PlayMineSound()
    {
        PlayClip(_mineClip);
    }    
}
