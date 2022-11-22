using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AppearAction : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    [SerializeField] RectTransform startPos;
    [SerializeField] Transform object2Move;

    [SerializeField] Image targetImage;

    Sequence seq;

    private void Awake()
    {
        seq = DOTween.Sequence();
    }

    private void OnEnable()
    {
        targetImage.color = new Color(255, 255, 255, 0);
        seq.Append(object2Move.transform.DOMove(targetPos.position, 1.5f));
        seq.Join(targetImage.DOFade(1, 1.5f));
    }

    private void OnDisable()
    {
        seq.Kill();
        object2Move.transform.position = startPos.position;
    }
}