using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerLevelText;
    Image image;

    private int level = 1;
    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            playerLevelText.text = $"¿ë»ç ({level})";
        }
    }

    private float price = 10;

    private float increaseDamage = 0.45f;

    private float increaseAttackDelay = 0.045f;

    public void UpgradeBtnClick()
    {
        if (GameManager.instance.Money >= price)
        {
            GameManager.instance.Money -= price;
            price += 166;
            PlayerProperty.instance.Damage += increaseDamage;
            PlayerProperty.instance.MiningDelay -= increaseAttackDelay;
            level++;
            Debug.Log($"price : {price}, Damage : {PlayerProperty.instance.Damage}, Delay : {PlayerProperty.instance.MiningDelay }");
        }
        else
        {
            Debug.Log("µ·¾øÀ½");
            Debug.Log($"price : {price}, Damage : {PlayerProperty.instance.Damage}, Delay : {PlayerProperty.instance.MiningDelay }");
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (price <= GameManager.instance.Money)
        {
            image.color = new Color(255, 255, 255, 1);
        }
        else
        {
            image.color = new Color(255, 255, 255, 0);
        }
    }
}
