using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class TitleAnim : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject startText;
    private void Start()
    {
        Sequence seq = DOTween.Sequence()
        .Append(text.DOText("전생에 마왕을 잡은 세계 최강의 용사였던 내가 환생하고 나니 마왕의 저주에 걸려 곡괭이 밖에 못쓰게 되버려 삼류광부로 전직해 마왕을 잡으러 가게 된 건에 대하여.", 4).SetEase(Ease.Linear))
        .OnComplete(() =>
        {
            startText.SetActive(true);
        });
    }

}
