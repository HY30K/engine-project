using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningSpeedUpBuff : BuffMono
{
    private float time = 0;

    public override void Init(float t)
    {
        time = t;
    }

    private void OnEnable()
    {
        PlayerProperty.Instance.MiningDelay /= 1.5f;
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
        PlayerProperty.Instance.MiningDelay *= 1.5f;
    }
}
