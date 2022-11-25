using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogBoxOpen : MonoBehaviour
{
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject targetPos;

    private void OnEnable()
    {
        transform.DOMove(targetPos.transform.position, 2f).SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        transform.position = startPos.transform.position;
    }

}
