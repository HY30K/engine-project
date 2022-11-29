using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

//                    ¹ã / ³·
//ºñ¿À´Â³¯, È­Ã¢ÇÑ³¯, ºñ ¸¹ÀÌ¿À´Â ³¯, ºñ ´õ ¸¹ÀÌ ¿À´Â³¯
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
    [SerializeField] GameObject[] audioObj;
    float time = 0;

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
            globalLight.intensity = 0.22f;
        }
        else
        {
            ParticleActiveChange(0);
            globalLight.intensity = 0.7f;
        }
    }

    IEnumerator TimeChange()
    {
        while (true)
        {
            Debug.Log("¾ßÈ£");
            yield return new WaitForSeconds(15);
            AudioActiveChange(-1);
            Debug.Log("¾ßÈ£");
            if (time >= 3600) //¹ã
            {
                Debug.Log("¾ßÈ£");
                if (currentWeather == Weather.Storm)
                {
                    Debug.Log("ÆøÇ³Ä¡´Â ¹ã");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.35f, 3);
                    ParticleActiveChange(2);
                    AudioActiveChange(1);
                }
                else if (currentWeather == Weather.Rainny)
                {
                    Debug.Log("ºñ¿À´Â ¹ã");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.4f, 3);
                    ParticleActiveChange(1);
                    AudioActiveChange(1);
                }
                else if (currentWeather == Weather.Sunny)
                {
                    Debug.Log("È­Ã¢ÇÑ ¹ã");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.5f, 3);
                    ParticleActiveChange(0);
                }
                else if (currentWeather == Weather.HardRainny)
                {
                    Debug.Log("ºñ ¸¹ÀÌ ¿À´Â ¹ã");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.2f, 3);
                    ParticleActiveChange(3);
                    AudioActiveChange(0);
                }
            }
            else //³·
            {
                if (currentWeather == Weather.Storm)
                {
                    Debug.Log("ÆøÇ³Ä¡´Â ³·");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.8f, 3);
                    ParticleActiveChange(2);
                    AudioActiveChange(1);
                }
                else if (currentWeather == Weather.Rainny)
                {
                    Debug.Log("ºñ¿À´Â ³·");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.9f, 3);
                    ParticleActiveChange(1);
                    AudioActiveChange(1);
                }
                else if (currentWeather == Weather.Sunny)
                {
                    Debug.Log("È­Ã¢ÇÑ ³·");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 1, 3);
                    ParticleActiveChange(0);
                }
                else if (currentWeather == Weather.HardRainny)
                {
                    Debug.Log("ºñ ¸¹ÀÌ¿À´Â ³·");
                    DOTween.To(() => globalLight.intensity, x => globalLight.intensity = x, 0.75f, 3);
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
        }
    }

}
