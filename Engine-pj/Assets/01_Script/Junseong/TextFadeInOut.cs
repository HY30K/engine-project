using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFadeInOut : MonoBehaviour
{
    public GameObject TextGameObject;
    public Vector3 firstTransform;
    public Vector3 transformPos;
    TextMeshPro text;
    float texttime = 0f;
    float textftime = 1.3f;
    public int arrowDirection;
    public float currentColorA;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        firstTransform = text.transform.position;
        transformPos = text.transform.position;
    }
    private void Update()
    {
        text.transform.position = transformPos;
        currentColorA = text.color.a;
    }
    public void FadeIN()
    {
        StopCoroutine("FadeOut");
        StartCoroutine("FadeIn");
    }
    public void FadeOUT()
    {
        StopCoroutine("FadeIn");
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn()
    {
        Color alpha = text.color;
        texttime = 0f;
        while(alpha.a < 1f)
        {
            texttime +=Time.deltaTime/textftime;
            transformPos.x = Mathf.Lerp(firstTransform.x,firstTransform.x + arrowDirection, texttime / textftime);
            //transformPos.y = Mathf.Lerp(firstTransform.y,firstTransform.y, textftime);
            alpha.a = Mathf.Lerp(0, 1,texttime);
            text.color = alpha;
            yield return null;
        }
    }
    IEnumerator FadeOut()
    {
        Color alpha = text.color;
        texttime = 0f;
        while (alpha.a > 0f)
        {
            texttime += Time.deltaTime / textftime / 30;
            transformPos.x = Mathf.Lerp(transformPos.x, firstTransform.x, texttime / textftime);
            //transformPos.y = Mathf.Lerp(transformPos.y, firstTransform.y, textftime);
            alpha.a = Mathf.Lerp(currentColorA, 0, texttime);
            text.color = alpha;
            yield return null;
        }
    }
}
