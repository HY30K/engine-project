using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MineralType
{
    Ground,
    Rock,
    Coal,
    Silver,
    Gold,
    Diamond
}

public class MineralScript : MonoBehaviour
{
    public MineralType MineralType;
    public float hp;
    TerrainGeneration tg;

    private void OnEnable()
    {
        SetType();
    }

    private void Update()
    {
        if (hp < 0)
        {
            Destroy(gameObject);//나중에 풀링해줘야함
            //gameObject.SetActive(false);
            Debug.Log("광물hp 0");
        }
    }

    public void OnOreBreak()
    {
        if (hp < 0)
        {
            tg.isOreAlive[(int)transform.position.x, (int)transform.position.y] = false;// 해당위치에 bool값 false로 변환
            //hp 0 일때 실행할것들
        }
    }
    void SetType()// 광석 타입에따른 피통 지정
    {
        switch (MineralType)
        {
            case MineralType.Ground:
                hp = 3;
                break;
            case MineralType.Rock:
                hp = 4;
                break;
            case MineralType.Coal:
                hp = 5;
                break;
            case MineralType.Silver:
                hp = 6;
                break;
            case MineralType.Gold:
                hp = 7;
                break;
            case MineralType.Diamond:
                hp = 8;
                break;
        }
    }

}
