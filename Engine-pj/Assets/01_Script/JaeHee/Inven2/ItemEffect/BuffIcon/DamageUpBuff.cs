using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageUpBuff : BuffMono 
{
    private float time = 0;

    public override void Init(float t)
    {
        time = t;
    }

    private void OnEnable()
    {
        PlayerProperty.Instance.Damage *= 1.3f;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        PlayerProperty.Instance.Damage /= 1.3f;
    }

}
