using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private PoolingListSO _poolingList;

    [SerializeField] TextMeshProUGUI _money;
    private float money;
    public float Money
    {
        get { return money; }
        set
        {
            money = value;
            _money.text = $"{money}$";
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple GameManager is running");
        }
        instance = this;
        PoolManager.Instance = new PoolManager(transform);
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _poolingList.list.Count; i++)
        {
            PoolManager.Instance.CreatePool(_poolingList.list[i].prefab, _poolingList.list[i].poolCount);
        }
    }
}
