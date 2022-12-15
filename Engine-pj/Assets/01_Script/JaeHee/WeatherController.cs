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
    [SerializeField] Light2D playerLight;
    [SerializeField] GameObject[] rainGenerator;
    [SerializeField] Camera mainCam;
    [SerializeField] float weatherChangeTime = 120;
    [SerializeField] GameObject[] audioObj;
    //35 /-40
    float time = 0;
    float currentGroundIntensity = 1;

    Weather currentWeather = Weather.None;
    bool isPlayerAboveGround = false;

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
            rainGenerator[i].transform.position = new Vector2(Mathf.Clamp(rainGenerator[i].transform.position.x, -40, 35), 7);
        }
        time += Time.deltaTime;
        if (time >= 7200)
        {
            time = 0;
        }

        if (TeleportCollider.instance.isEnterDungeon)
        {
            ParticleActiveChange(-2);
            AudioActiveChange(-1);
        }

        isPlayerAboveGround = mainCam.transform.position.y > -5;

        if (isPlayerAboveGround == false)
        {
            AudioActiveChange(-1);
            globalLight.intensity = 0.15f;
            playerLight.transform.gameObject.SetActive(true);
        }
        else
        {
            globalLight.intensity = currentGroundIntensity;
            playerLight.transform.gameObject.SetActive(false);
        }
    }

    IEnumerator TimeChange()
    {
        while (true)
        {
            Debug.Log("��ȣ");
            yield return new WaitForSeconds(15);
            AudioActiveChange(-1);
            Debug.Log("��ȣ");
            if (time >= 3600) //��
            {
                Debug.Log("��ȣ");
                if (currentWeather == Weather.Storm)
                {
                    Debug.Log("��ǳġ�� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.35f, 3);
                    currentGroundIntensity = 0.35f;
                    ParticleActiveChange(2);
                    AudioActiveChange(1);
                }
                else if (currentWeather == Weather.Rainny)
                {
                    Debug.Log("����� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.4f, 3);
                    currentGroundIntensity = 0.4f;
                    ParticleActiveChange(1);
                    AudioActiveChange(1);
                }
                else if (currentWeather == Weather.Sunny)
                {
                    Debug.Log("ȭâ�� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.5f, 3);
                    currentGroundIntensity = 0.5f;
                    ParticleActiveChange(0);
                }
                else if (currentWeather == Weather.HardRainny)
                {
                    Debug.Log("�� ���� ���� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.2f, 3);
                    currentGroundIntensity = 0.2f;
                    ParticleActiveChange(3);
                    AudioActiveChange(0);
                }
            }
            else //��
            {
                if (currentWeather == Weather.Storm)
                {
                    Debug.Log("��ǳġ�� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.8f, 3);
                    currentGroundIntensity = 0.8f;
                    ParticleActiveChange(2);
                    AudioActiveChange(1);
                }
                else if (currentWeather == Weather.Rainny)
                {
                    Debug.Log("����� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.9f, 3);
                    currentGroundIntensity = 0.9f;
                    ParticleActiveChange(1);
                    AudioActiveChange(1);
                }
                else if (currentWeather == Weather.Sunny)
                {
                    Debug.Log("ȭâ�� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 1, 3);
                    currentGroundIntensity = 1;
                    ParticleActiveChange(0);
                }
                else if (currentWeather == Weather.HardRainny)
                {
                    Debug.Log("�� ���̿��� ��");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.75f, 3);
                    currentGroundIntensity = 0.75f;
                    ParticleActiveChange(3);
                    AudioActiveChange(0);
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

    void AudioActiveChange(int index)
    {
        for (int i = 0; i < audioObj.Length; i++)
        {
            audioObj[i].SetActive(false);
        }

        if (index <= -1 || index > audioObj.Length) return;

        audioObj[index].SetActive(true);
    }

    void ParticleActiveChange(int cnt)
    {
        for (int i = 0; i < rainGenerator.Length; i++)
        {
            rainGenerator[i].SetActive(false);
        }

        if (cnt < -1) return;
        if (cnt > rainGenerator.Length) cnt = rainGenerator.Length;

        for (int i = 0; i < cnt; i++)
        {
            rainGenerator[i].SetActive(true);
            Debug.Log(rainGenerator[i] + "����");
        }
    }
}
