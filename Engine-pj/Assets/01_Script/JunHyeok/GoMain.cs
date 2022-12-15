using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMain : MonoBehaviour
{
    Vector3 firstPos;

    private bool waiting = false;
    private bool isClickB = false;
    public bool canTp = false;
    [SerializeField] GameObject prefabs;
    [SerializeField] GameObject _currentCam;
    [SerializeField] GameObject shopCamera;

    [SerializeField] AudioSource MineAudioSource;
    [SerializeField] AudioSource ShopAudioSource;
    [SerializeField] AudioSource DungeonAudioSource;
    [SerializeField] AudioSource TeleportAudioSource;


    GameObject Effect;

    private void Awake()
    {
        _currentCam = shopCamera;
    }
    void Update()
    {
        if (_currentCam != null)
        {
            ICinemachineCamera currentCam
           = CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera;
            _currentCam = currentCam.VirtualCameraGameObject;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            firstPos = transform.position;
            //isClickB = true;
            StartCoroutine(DelayTime());
            Effect = Instantiate(prefabs, transform.position, Quaternion.identity);
        }


        if (firstPos != transform.position)
        {

            StopCoroutine("DelayTime");
            if (Effect != null)
            {
                Destroy(Effect);
                //PoolManager.Instance.Push(Effect);
            }

        }

        if (canTp)
        {
            isClickB = false;
            canTp = false;
            transform.position = new Vector3(6, -2, 0);
            TeleportCollider.instance.isEnterDungeon = false;
            MineAudioSource.Stop();
            DungeonAudioSource.Stop();
            _currentCam.SetActive(false);
            shopCamera.SetActive(true);
            ShopAudioSource.Play();
            TeleportAudioSource.Stop();
            TeleportAudioSource.Play();
           
            if (Effect != null)
            {
                Destroy(Effect);
                //PoolManager.Instance.Push(Effect);
            }
        }

    }

    IEnumerator DelayTime()
    {
        isClickB = true;
        waiting = true;

        yield return new WaitForSeconds(2f);

        if (firstPos == transform.position)
        {
            canTp = true;
        }

        waiting = false;

    }
}