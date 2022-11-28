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
            playerLevelText.text = $"용사 ({level})";
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
            price += 80;
            PlayerProperty.Instance.Damage += increaseDamage;
            PlayerProperty.Instance.MiningDelay -= increaseAttackDelay;
            level++;
        }
        playerLevelText.text = $"용사 (Lv. {level})";
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
