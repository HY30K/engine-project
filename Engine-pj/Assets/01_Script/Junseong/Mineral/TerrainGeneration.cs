using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    [SerializeField]
    private List<MineralSO> mineralInfo;
    private float _mineralSpeed;
    public int worldSize = 100;

    public GameObject Mineral;

    [Header("~±¤¼® ½ºÇÁ¶óÀÌÆ®")]
    // ±¤¼®µé
    public Sprite ground;
    public Sprite bedRock;
    public Sprite soil;
    public Sprite rockOre;
    public Sprite coalOre;
    public Sprite coalOre_alt;
    public Sprite silverOre;
    public Sprite silverOre_alt;
    public Sprite goldOre;
    public Sprite goldOre_alt;
    public Sprite DiamondOre;
    public Sprite DiamondOre_alt;
    public Sprite RubyOre;
    public Sprite RubyOre_alt;
    public Sprite EmeraldOre;
    public Sprite EmeraldOre_alt;
    public Sprite BrownOre;
    public Sprite BrownOre_alt;

    [Header("~±¤¼® Ã¼·Â")]
    //±¤¼®µé ÇÇÅë
    public int GroundHp = 1;
    public int RockHp = 2;  
    public int CoalHp = 3;
    public int SilverHp = 4;
    public int GoldHp = 5;
    public int DiamondHp = 10;
    public int RubyHp = 7;
    public int EmeraldHp = 8;
    public int BrownHp = 3;
    
    [Header("~±¤¹°º° ½ºÆùÈ®·ü")]
    // ±¤¹° ½ºÆù È®·ü
    public int coalSpawnPercent = 80;
    public int silverSpawnPercent = 80;
    public int GoldSpawnPercent = 60;
    public int BrownSpawnPercent = 40;
    public int RubySpawnPercent = 20;
    public int EmeraldSpawnPercent = 10;
    public int DiamondSpawnPercent = 5;

    public bool[,] isOreAlive;

    //private MineralScript _mineralScript;
    public Color bedRockColor;
    private void Start()
    {
        //_mineralScript = GetComponent<MineralScript>(;
        IsOreSpawn();
        //GenerateStting();
        GenerateTerrain();
    }

    private void IsOreSpawn()
    {
        isOreAlive = new bool[worldSize + 1, worldSize + 1];
        for (int x = 0; x < worldSize; x++)
        {
            for (int y = 0; y < worldSize; y++)
            {
                isOreAlive[x, y] = true;
            }
        }
    }

    //public void GenerateStting()
    //{
    //    for(int x = 0; x > -worldSize; x--)
    //    {
    //        for(int y = 0; y > -worldSize; y--)
    //        {
                
    //        }
    //    }
    //}


    private void GenerateTerrain()
    {
        //±¤»ê ²Ù¹Ì±â ºÎºÐ
        //for(int i = 15; i>0; i++)
        //{
        //    for(int j = 0; j < worldSize; j++)
        //    {
        //        GameObject newObj = Instantiate(Mineral);
        //    }
        //}
 
        //¶¥ÆÈ ºÎºÐ »ý¼º
        for (int x = 0; x >= -worldSize; x--)
        {
            for (int y = 10; y >= -worldSize - 5; y--)
            {

                //if (isOreAlive[x, y])
                //{
                if (y > 0 && x > -worldSize && x < 0) continue;
                GameObject newObj = Instantiate(Mineral);
                newObj.transform.parent = this.transform;
                newObj.transform.position = (Vector2)transform.position + new Vector2(x + 0.5f, y + 0.7f);
            
                if(y == -worldSize || x == -worldSize || x == 0)
                {
                    newObj.GetComponent<SpriteRenderer>().sprite = bedRock;
                    newObj.GetComponent<SpriteRenderer>().color = bedRockColor;
                    newObj.GetComponent<MineralScript>().hp = 10000;
                }
                else
                {
                    int OreSpawnPercent = UnityEngine.Random.Range(0, 1000);
                    int Random1or2 = UnityEngine.Random.Range(0, 11);
                    if(y == 0)
                    {
                        newObj.GetComponent<SpriteRenderer>().sprite = ground;
                        //newObj.GetComponent<SpriteRenderer>().color = Color.red;
                        newObj.GetComponent<MineralScript>().MineralType = MineralType.Ground;
                        //newObj.GetComponent<MineralScript>().hp = mineralInfo[0].OreHp();
                        newObj.GetComponent<MineralScript>().hp = GroundHp;
                    
                    }
                    else if (y >= -2)
                    {
                        newObj.GetComponent<SpriteRenderer>().sprite = soil;
                        newObj.GetComponent<MineralScript>().MineralType = MineralType.Ground;
                        newObj.GetComponent<MineralScript>().hp = GroundHp;
                    }
                    else {
                        if (y>=-100)//µ¹
                        {
                        
                            newObj.GetComponent<SpriteRenderer>().sprite = rockOre;
                            //if(Random1or2 < 4) newObj.GetComponent<SpriteRenderer>().color = Color.gray;
                            newObj.GetComponent<MineralScript>().MineralType = MineralType.Rock;
                            newObj.GetComponent<MineralScript>().hp = RockHp;
                        }
                        if (y <= -5 && y >= -100)// ¼®Åº
                        {
                            //int coalSpawnPoint = UnityEngine.Random.Range(0, 100);
                            if (OreSpawnPercent < coalSpawnPercent)
                            {
                                if (Random1or2 < 3)
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = coalOre_alt;
                                    newObj.GetComponent<MineralScript>().hp = CoalHp * 1.5f;   
                                }
                                else
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = coalOre;
                                    newObj.GetComponent<MineralScript>().hp = CoalHp;   
                                }
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Coal;
                            }
                        }
                        if (y <= -10 && y >= -80)// ½Ç¹ö
                        {
                            if (OreSpawnPercent < silverSpawnPercent)
                            {
                                if(Random1or2 < 3)
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = silverOre_alt;
                                    newObj.GetComponent<MineralScript>().hp = SilverHp * 1.5f;   

                                }
                                else
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = silverOre;
                                    newObj.GetComponent<MineralScript>().hp = SilverHp;   
                                }
                                //newObj.GetComponent<SpriteRenderer>().color = Color.cyan;
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Silver;
                            }

                        }
                        if (y <= -20 && y >= -95)// °ñµå
                        {
                            if (OreSpawnPercent < GoldSpawnPercent)
                            {
                                if(Random1or2 < 3)
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = goldOre_alt;
                                    newObj.GetComponent<MineralScript>().hp = GoldHp * 1.5f;
                                }
                                else
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = goldOre;
                                    newObj.GetComponent<MineralScript>().hp = GoldHp;   
                                }
                                //newObj.GetComponent<SpriteRenderer>().color = Color.yellow;
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Gold;
                            }

                        }

                        if (y <= -17 && y >= -30 || y <= -50 && y >= -80)// ºê¶ó¿î
                        {
                            if (OreSpawnPercent < BrownSpawnPercent)
                            {
                                if (Random1or2 < 4)
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = BrownOre_alt;
                                    newObj.GetComponent<MineralScript>().hp = BrownHp * 1.5f;
                                }
                                else
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = BrownOre;
                                    //newObj.GetComponent<SpriteRenderer>().color = Color.blue;
                                    newObj.GetComponent<MineralScript>().hp = BrownHp;
                                }
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Brown;
                            }
                        }
                        if (y <= -35 && y >= -70 || y <= -80 && y >= -95)// ·çºñ
                        {
                            if (OreSpawnPercent < RubySpawnPercent)
                            {
                                if (Random1or2 < 3)
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = RubyOre_alt;
                                    newObj.GetComponent<MineralScript>().hp = RubyHp* 1.5f;
                                }
                                else
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = RubyOre;
                                    //newObj.GetComponent<SpriteRenderer>().color = Color.blue;
                                    newObj.GetComponent<MineralScript>().hp = RubyHp;
                                }
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Ruby;
                            }
                        }

                        if (y <= -36 && y >= -45 || y <= -50 && y >= -100)// ¿¡¸Þ¶öµå
                        {
                            if (OreSpawnPercent < EmeraldSpawnPercent)
                            {
                                if (Random1or2 < 3)
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = EmeraldOre_alt;
                                    newObj.GetComponent<MineralScript>().hp = EmeraldHp * 1.5f;
                                }
                                else
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = EmeraldOre;
                                    //newObj.GetComponent<SpriteRenderer>().color = Color.blue;
                                    newObj.GetComponent<MineralScript>().hp = EmeraldHp;
                                }
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Emerald;
                            }
                        }

                        if (y <= -50 && y >= -55 || y <= -70 && y >= -100)// ´ÙÀÌ¾Æ
                        {
                            if (OreSpawnPercent < DiamondSpawnPercent)
                            {
                                if (Random1or2 < 3)
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = DiamondOre_alt;
                                    newObj.GetComponent<MineralScript>().hp = DiamondHp * 1.5f;
                                }
                                else
                                {
                                    newObj.GetComponent<SpriteRenderer>().sprite = DiamondOre;
                                    //newObj.GetComponent<SpriteRenderer>().color = Color.blue;
                                    newObj.GetComponent<MineralScript>().hp = DiamondHp;
                                }
                                newObj.GetComponent<MineralScript>().MineralType = MineralType.Diamond;
                            }
                        }
                    }
                }
            }
        }
    }
}