using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOverTxt : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject startText;
    private void Start()
    {
        Sequence seq = DOTween.Sequence()
        .Append(text.DOText("Game \nOver", 2).SetEase(Ease.Linear))
        .OnComplete(() =>
        {
            startText.SetActive(true);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
