using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class TextScaler : MonoBehaviour
{
    GameObject text;

    private void Awake()
    {
        text = this.gameObject;
        StartCoroutine(ChangeScale());
    }

    IEnumerator ChangeScale()
    {
        while (true)
        {
            text.transform.DOScale(Vector3.one * 1.2f, 2);
            yield return new WaitForSeconds(1);
            text.transform.DOScale(Vector3.one, 2);
            yield return new WaitForSeconds(1);
        }
    }
}