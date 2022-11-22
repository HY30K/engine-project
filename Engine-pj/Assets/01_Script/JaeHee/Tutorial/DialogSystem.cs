using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance = null;

    [SerializeField] string[] arr;
    int arrCnt = 0;

    [SerializeField] TextMeshProUGUI mainText;
    [SerializeField] GameObject dialogUI;
    [SerializeField] GameObject playerImage;
    [SerializeField] GameObject npcImage;

    Vector2 originPos;
    bool loop = true;

    Image _player;
    Image _npcImage;

    private void Awake()
    {

        _player = playerImage.transform.GetComponent<Image>();
        _npcImage = npcImage.transform.GetComponent<Image>();
        originPos = dialogUI.transform.position;
        if (instance == null) instance = this;

    }

    private void Start()
    {
        StartCoroutine(Dialog());
    }

    private void Update()
    {
        if (mainText.text.Substring(0, 0) == "<")
        {
            _player.DOColor(new Color(135, 135, 135, 0.5f), 0.2f);
            _npcImage.DOColor(new Color(255, 255, 255, 1), 0.2f);
        }
        else
        {
            _npcImage.DOColor(new Color(135, 135, 135, 0.5f), 0.2f);
            _player.DOColor(new Color(255, 255, 255, 1), 0.2f);
        }
    }

    /// <summary>
    /// 하드코딩 어쩔수없다 ㅋㅋ
    /// </summary>
    /// <returns></returns>
    IEnumerator Dialog()
    {
        while (loop)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetMouseButtonDown(0));
            mainText.text = " ";

            Sequence seq;
            seq = DOTween.Sequence();
            try
            {
                seq.Append(mainText.DOText(arr[arrCnt], 1));
                seq.Join(dialogUI.transform.DOShakePosition(1, 1));
                seq.AppendCallback(() =>
                {
                    ++arrCnt;
                    dialogUI.transform.position = originPos;
                    seq.Kill();
                });
            }
            catch (System.Exception)
            {
                loop = false;
                throw;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
