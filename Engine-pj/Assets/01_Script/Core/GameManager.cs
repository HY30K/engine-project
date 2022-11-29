using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private PoolingListSO _poolingList;


    [SerializeField] TextMeshProUGUI _money;
    private float money = 1;
    public float Money
    {
        get { return money; }
        set
        {
            money = value;
            _money.text = $"{money}$";
        }
    }

    [SerializeField] Slider _slider;

    private float maxHealth = 100;//최대 체력
    private float health = 100; //체력
    public float MaxHealth
    {
        get { return maxHealth; }
        set
        {
            maxHealth = value;
            _slider.value = health / maxHealth;
        }
    }

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            _slider.value = health / maxHealth;
        }
    }

    public Light2D playerLight;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple GameManager is running");
        }
        instance = this;
        PoolManager.Instance = new PoolManager(transform);
        CreatePool();
        StartInit();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _poolingList.list.Count; i++)
        {
            PoolManager.Instance.CreatePool(_poolingList.list[i].prefab, _poolingList.list[i].poolCount);
        }
    }

    private void StartInit()
    {
        
    }
}
