using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSound : AudioPlayer
{
    [SerializeField]
    private AudioClip groundWalkClip = null , miningWalkClip = null;
    public void PlayGroundWalk()
    { 
        MovingPlayClip(groundWalkClip);
    }
    public void PlayMiningWalk()
    {
        MovingPlayClip(miningWalkClip);
    }

    public void StopSound()
    {
        StopClip();
    }
}
