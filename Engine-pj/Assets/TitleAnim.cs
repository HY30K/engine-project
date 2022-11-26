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
        .Append(text.DOText("������ ������ ���� ���� �ְ��� ��翴�� ���� ȯ���ϰ� ���� ������ ���ֿ� �ɷ� ��� �ۿ� ������ �ǹ��� ������η� ������ ������ ������ ���� �� �ǿ� ���Ͽ�.", 4).SetEase(Ease.Linear))
        .OnComplete(() =>
        {
            startText.SetActive(true);
        });
    }

}
