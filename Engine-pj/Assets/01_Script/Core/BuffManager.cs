using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    [SerializeField] GameObject[] buffArr;
    [SerializeField] GameObject buffParent;
    Dictionary<string, GameObject> buffs = new Dictionary<string, GameObject>();

    public static BuffManager instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("µÎ°³¾ß");
        }
            instance = this;

        for (int i = 0; i < buffArr.Length; i++)
        {
            buffs.Add(buffArr[i].name, buffArr[i]);
        }
    }

    public void SpawnBuffIcon(string name, float time = 60)
    {
        Debug.Log(11);
        GameObject buffIcon = Instantiate(buffs[name], buffParent.transform);
        Debug.Log(buffs[name]);
        buffIcon.GetComponent<BuffMono>().Init(time);
    }
}
