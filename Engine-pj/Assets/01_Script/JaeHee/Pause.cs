using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Image keyGuide;
    [SerializeField] GameObject pausePannel;

    [SerializeField] RectTransform pausePannelTargetPos;
    [SerializeField] RectTransform pausePannelOriginPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePannel.SetActive(true);
            pausePannel.transform.DOMove(pausePannelTargetPos.position, 1.5f).SetUpdate(true).SetEase(Ease.InOutElastic);
        }
    }

    public void Restart()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(pausePannel.transform.DOMove(pausePannelOriginPos.position, 1.5f).SetUpdate(true).SetEase(Ease.InOutElastic));
        seq.OnComplete(() =>
        {
            Time.timeScale = 1;
            pausePannel.SetActive(false);
        }).SetUpdate(true);
    }

    public void KeyGuideOpen()
    {
        keyGuide.gameObject.SetActive(true);
        pausePannel.SetActive(false);
    }

    public void KeyGuideClose()
    {
        keyGuide.gameObject.SetActive(false);
        pausePannel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
