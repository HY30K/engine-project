using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

//                    �� / ��
//����³�, ȭâ�ѳ�, �� ���̿��� ��, �� �� ���� ���³�
enum Weather
{
    Sunny,
    Rainny,
    HardRainny,
    Storm,
    None
}

public class WeatherController : MonoBehaviour
{
    [SerializeField] Light2D globalLight;
    [SerializeField] GameObject[] rainGenerator;
    [SerializeField] Camera mainCam;
    [SerializeField] float weatherChangeTime = 120;
    float time = 0;

    Weather currentWeather = Weather.None;

    private void Start()
    {
        StartCoroutine(ChangeWeather());
        StartCoroutine(TimeChange());
    }

    private void Update()
    {
        for (int i = 0; i < rainGenerator.Length; i++)
        {
            rainGenerator[i].transform.position = new Vector3(mainCam.transform.position.x, 7, -1);
        }
        time += Time.deltaTime;
        if (time >= 7200)
        {
            time = 0;
        }
    }

    IEnumerator TimeChange()
    {
        while (true)
        {
            Debug.Log("��ȣ");
            yield return new WaitForSeconds(15);

            Debug.Log("��ȣ");
            if (time >= 3600) //��
            {
                Debug.Log("��ȣ");
                if (currentWeather == Weather.Storm)
                {
                    Debug.Log("��ǳġ�� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.35f, 3);
                    ParticleActiveChange(2);
                }
                else if (currentWeather == Weather.Rainny)
                {
                    Debug.Log("����� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.4f, 3);
                    ParticleActiveChange(1);
                }
                else if (currentWeather == Weather.Sunny)
                {
                    Debug.Log("ȭâ�� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.5f, 3);
                    ParticleActiveChange(0);
                }
                else if (currentWeather == Weather.HardRainny)
                {
                    Debug.Log("�� ���� ���� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.2f, 3);
                    ParticleActiveChange(3);
                }
            }
            else //��
            {
                if (currentWeather == Weather.Storm)
                {
                    Debug.Log("��ǳġ�� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.8f, 3);
                    ParticleActiveChange(2);
                }
                else if (currentWeather == Weather.Rainny)
                {
                    Debug.Log("����� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.9f, 3);
                    ParticleActiveChange(1);
                }
                else if (currentWeather == Weather.Sunny)
                {
                    Debug.Log("ȭâ�� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 1, 3);
                    ParticleActiveChange(0);
                }
                else if (currentWeather == Weather.HardRainny)
                {
                    Debug.Log("�� ���̿��� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.75f, 3);
                    ParticleActiveChange(3);
                }
            }
        }
    }

    IEnumerator ChangeWeather()
    {
        while (true)
        {
            currentWeather = (Weather)Random.Range(0, 4);
            Debug.Log(currentWeather);
            yield return new WaitForSeconds(Random.Range(weatherChangeTime * 0.8f, weatherChangeTime * 1.2f));
            yield return new WaitForSeconds(1);
        }
    }

    void ParticleActiveChange(int cnt)
    {
        for (int i = 0; i < rainGenerator.Length; i++)
        {
            rainGenerator[i].SetActive(false);
        }

        if (cnt > rainGenerator.Length) cnt = rainGenerator.Length;

        for (int i = 0; i < cnt; i++)
        {
            rainGenerator[i].SetActive(true);
        }
    }

}
