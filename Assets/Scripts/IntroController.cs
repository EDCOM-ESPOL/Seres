using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroController : VideoController {

    //public VideoPlayer player;
    //public GameObject panel;
    float videoLenght;

    // Use this for initialization
    void Start () {
        //panel.SetActive(false);

        Debug.Log(base.player.clip.length);
        videoLenght = (player.frameCount / player.frameRate);
        //player.time = 30.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(player.time);
        if (player.time >= 34.0f)
        {
            panel.SetActive(true);
            if (player.time >= 38.0f)
            {
                player.Pause();

            }

        }
        else
        {
            panel.SetActive(false);
        }
    }


}
