using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public delegate void MyDelegate();

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

    IEnumerator Dialog()
    {
        while (loop)
        {
            yield return new WaitForSeconds(arr[arrCnt].Length * 0.12f);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetMouseButtonDown(0));

            mainText.text = " ";

            Sequence seq = DOTween.Sequence();
            Invoke("ChangeSize", 0.2f);
            seq.Append(mainText.DOText(arr[arrCnt], arr[arrCnt].Length * 0.12f))
            .Join(dialogUI.transform.DOShakePosition(arr[arrCnt++].Length * 0.12f, 50, 10, 0))
            .AppendCallback(() =>
            {
                seq.Kill();
                dialogUI.transform.position = originPos;
            });
            if (arrCnt > arr.Length) loop = false;
        }
    }

    private void ChangeSize()
    {
        if (mainText.text.Substring(0, 1) == "[")
        {
            Debug.Log("안내자");
            _player.DOColor(new Color(135, 135, 135, 0.5f), 0.2f);
            _player.rectTransform.DOScale(new Vector2(1, 1f), 0.2f);
            _npcImage.DOColor(new Color(255, 255, 255, 1), 0.2f);
            _npcImage.rectTransform.DOScale(new Vector2(1.2f, 1.2f), 0.2f);

        }
        else
        {
            Debug.Log("플레이어");
            _npcImage.DOColor(new Color(135, 135, 135, 0.5f), 0.2f);
            _npcImage.rectTransform.DOScale(new Vector2(1, 1f), 0.2f);
            _player.DOColor(new Color(255, 255, 255, 1), 0.2f);
            _player.rectTransform.DOScale(new Vector2(1.2f, 1.2f), 0.2f);
        }
    }
}
