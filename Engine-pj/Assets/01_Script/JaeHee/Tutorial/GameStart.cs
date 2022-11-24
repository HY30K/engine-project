using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameStart : MonoBehaviour
{
    public static GameStart instance = null;

    [SerializeField] string[] arr;
    int arrCnt = 0;

    [SerializeField] GameObject dialogOUi;
    [SerializeField] TextMeshProUGUI mainText;
    [SerializeField] GameObject dialogUI;
    [SerializeField] GameObject playerImage;
    [SerializeField] GameObject npcImage;
    [SerializeField] GameObject playerStun;
    Vector2 originPos;
    bool loop = true;
    private bool isStart = false;

    [SerializeField] TextMeshProUGUI text;

    Image _player;
    Image _npcImage;

    private void Awake()
    {
        _player = playerImage.transform.GetComponent<Image>();
        _npcImage = npcImage.transform.GetComponent<Image>();
        originPos = dialogUI.transform.position;
        if (instance == null) instance = this;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartBtn();
        }
    }

    public void StartBtn()
    {
        if (!isStart)
        {
            isStart = true;
            dialogOUi.SetActive(true);
            text.gameObject.SetActive(false);
            playerStun.SetActive(false);
            StartCoroutine(Dialog());
        }
    }


    IEnumerator Dialog()
    {
        while (loop)
        {
            yield return new WaitForSeconds(arr[arrCnt].Length * 0.13f);
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)));
            mainText.text = " ";

            Sequence seq = DOTween.Sequence();
            seq.PrependInterval(0.1f);

            Invoke("ChangeSize", 0.2f);

            seq.Append(mainText.DOText(arr[arrCnt], arr[arrCnt].Length * 0.12f))
            .Join(dialogUI.transform.DOShakePosition(arr[arrCnt++].Length * 0.1f, 3, 10, 0))
            .OnComplete(() =>
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
