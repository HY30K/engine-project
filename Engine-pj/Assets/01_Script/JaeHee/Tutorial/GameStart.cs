using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameStart : MonoBehaviour
{

    [SerializeField] string[] arr;
    int arrCnt = 0;

    [SerializeField] GameObject dialogUi;
    [SerializeField] TextMeshProUGUI mainText;
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject playerImage;
    [SerializeField] GameObject npcImage;
    [SerializeField] GameObject playerStun;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject player;
    [SerializeField] RectTransform titleTargetPos;

    [SerializeField] GameObject mainCanvas;
    Vector2 titleOrigin;
    Vector2 originPos;

    bool endOfSentence = true;
    bool loop = true;

    bool isFirstClick = true;

    private bool isStart = false;

    [SerializeField] TextMeshProUGUI text;

    Image _player;
    Image _npcImage;
    Sequence seq;

    private void Awake()
    {
        _player = playerImage.transform.GetComponent<Image>();
        _npcImage = npcImage.transform.GetComponent<Image>();

        Sequence title = DOTween.Sequence();
        titleOrigin = mainPanel.transform.position;
        title.Append(mainPanel.transform.DOMove(titleTargetPos.position, 2).SetEase(Ease.OutElastic))
        .OnComplete(() =>
        {
            mainPanel.GetComponent<TitleAnim>().TitleStart();
        });
    }

    private void Update()
    {
        if (Input.anyKeyDown && isFirstClick)
        {
            StartBtn();
        }
    }

    public void StartBtn()
    {
        if (!isStart && text.gameObject.activeSelf)
        {
            isFirstClick = false;
            seq = DOTween.Sequence();
            seq.Append(mainPanel.transform.DOMove(titleOrigin, 2).SetEase(Ease.InBack))
            .Join(text.DOFade(0, 1))
            .Join(playerStun.GetComponent<SpriteRenderer>().DOFade(0, 1))
            .OnComplete(() =>
            {
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
            originPos = dialogBox.transform.position;
            yield return new WaitForSeconds(arrCnt <= arr.Length ? arr[arrCnt].Length * 0.01f : 1);
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
            seq.Join(dialogBox.transform.DOShakePosition(arr[arrCnt++].Length * 0.1f, 3, 10, 0));
            seq.OnComplete(() =>
            {
                dialogBox.transform.position = originPos;
                endOfSentence = true;
                seq.Kill();
            });
            if (arrCnt == arr.Length) loop = false;
        }
        Debug.Log("대화 종료");
        dialogUi.SetActive(false);
        player.SetActive(true);
        mainCanvas.SetActive(true);


    }

    public void Skip()
    {
        loop = false;
        dialogUi.SetActive(false);
        player.SetActive(true);
        mainCanvas.SetActive(true);

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
