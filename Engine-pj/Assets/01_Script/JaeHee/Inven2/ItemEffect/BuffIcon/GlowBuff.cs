using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowBuff : BuffMono
{
    private float time = 0;

    public override void Init(float t)
    {
        time = t;
    }

    private void OnEnable()
    {
        GameManager.instance.playerLight.intensity *= 1.3f;
        GameManager.instance.playerLight.pointLightOuterRadius += 1;
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
        GameManager.instance.playerLight.intensity /= 1.3f;
        GameManager.instance.playerLight.pointLightOuterRadius -= 1;
    }

}
