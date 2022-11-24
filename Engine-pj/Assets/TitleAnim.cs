using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class TitleAnim : MonoBehaviour
{
    [SerializeField] GameObject targetPos;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject startText;
    private void Start()
    {
        Sequence seq = DOTween.Sequence()
        .Append(transform.DOMove(targetPos.transform.position, 3f).SetEase(Ease.InOutBack))
        .Append(text.DOText("������ ������ ���� ���� �ְ��� ��翴�� ���� ȯ���ϰ� ���� ������ ���ֿ� �ɷ� ��� �ۿ� ������ �ǹ��� ������η� ������ ������ ������ ���� �� �ǿ� ���Ͽ�.", 5))
        .OnComplete(() =>
        {
            startText.SetActive(true);
        });
    }

}
