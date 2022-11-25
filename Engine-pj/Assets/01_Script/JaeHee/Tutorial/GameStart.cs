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

    [SerializeField] GameObject dialogUi;
    [SerializeField] TextMeshProUGUI mainText;
    [SerializeField] GameObject dialogUI;
    [SerializeField] GameObject playerImage;
    [SerializeField] GameObject npcImage;
    [SerializeField] GameObject playerStun;
    [SerializeField] GameObject mainPanel;

    Vector2 titleOrigin;
    Vector2 originPos;

    bool endOfSentence = true;
    bool loop = true;

    private bool isStart = false;

    [SerializeField] TextMeshProUGUI text;

    Image _player;
    Image _npcImage;
    Sequence seq;

    private void Awake()
    {
        _player = playerImage.transform.GetComponent<Image>();
        _npcImage = npcImage.transform.GetComponent<Image>();
        originPos = dialogUI.transform.position;
        titleOrigin = mainPanel.transform.position;
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
        if (!isStart && text.gameObject.activeSelf)
        {
            seq = DOTween.Sequence();
            seq.Append(mainPanel.transform.DOMove(titleOrigin, 2).SetEase(Ease.InBack))
            .Join(text.DOFade(0, 1))
            .Join(playerStun.GetComponent<SpriteRenderer>().DOFade(0, 1))
            .OnComplete(() =>
            {
                Debug.Log("시발");
                text.gameObject.SetActive(false);
                playerStun.SetActive(false);
                isStart = true;
                dialogUi.SetActive(true);
                seq.Kill();
                StartCoroutine(Dialog());
            });
        }
    }

    IEnumerator Dialog()
    {
        while (loop)
        {
            yield return new WaitForSeconds(arr[arrCnt].Length * 0.01f);
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            && endOfSentence);
            endOfSentence = false;
            Invoke("ChangeSize", 0.2f);

            seq = DOTween.Sequence();
            seq.AppendCallback(() =>
            {
                mainText.text = " ";
            });

            seq.Append(mainText.DOText(arr[arrCnt], arr[arrCnt].Length * 0.12f).SetEase(Ease.Linear));
            seq.Join(dialogUI.transform.DOShakePosition(arr[arrCnt++].Length * 0.1f, 3, 10, 0));
            seq.OnComplete(() =>
            {
                dialogUI.transform.position = originPos;
                endOfSentence = true;
                seq.Kill();
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
