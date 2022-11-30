using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayer2 : MonoBehaviour
{
    public VideoPlayer video;



    void Start()

    {

        video.url = Application.streamingAssetsPath + "/Intro 2";
    
}
}
