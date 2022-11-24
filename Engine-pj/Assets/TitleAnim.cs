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
    Sequence seq;

    private void Start()
    {
        seq.Append(transform.DOMove(targetPos.transform.position, 4f).SetEase(Ease.InOutBack));
        seq.Append(text.DOText("������ ������ ���� ���� �ְ��� ��翴�� ���� ȯ���ϰ� ���� ������ ���ֿ� �ɷ� ��� �ۿ� ������ �ǹ��� ������η� ������ ������ ������ ���� �� �ǿ� ���Ͽ�", 5));

    }

}
