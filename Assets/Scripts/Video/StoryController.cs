using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : VideoController {

    

    public StoryMetaData storyData;

    //bool isPaused = false;

    // Use this for initialization
    void Start () {
        storyData = new StoryMetaData(SessionManager.Instance.nombre_jugador, System.Math.Round(player.clip.length).ToString());
        panel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isPaused)
        {
            if (player.time >= 197.0f)
            {
                storyData.estado = "completado";
                panel.SetActive(true);
                if (player.time >= 207.0f)
                {
                    SendJSONAndGoToScene("ActivityHub");
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if (panel.activeSelf == false)
                    {
                        panel.SetActive(true);
                    }
                    else
                    {
                        panel.SetActive(false);
                    }
                }
            }
            
        }
        else
        {
            panel.SetActive(true);
        }

    }

    //public void Pause()
    //{
    //    AudioManager.Instance.PlaySFX("TinyButtonPush");
    //    player.Pause();
    //    pauseButton.SetActive(false);
    //    playButton.SetActive(true);
    //    isPaused = true;
    //}

    //public void UnPause()
    //{
    //    AudioManager.Instance.PlaySFX("TinyButtonPush");
    //    player.Play();
    //    pauseButton.SetActive(true);
    //    playButton.SetActive(false);
    //    isPaused = false;
    //}

    public void Avanza()
    {
        player.time = 195.0f;
    }

    public void SendJSONAndGoToScene(string sceneName)
    {
        storyData.fecha_fin = System.DateTime.Now.ToString("yyyy/MM/dd");
        storyData.tiempo_juego = System.Math.Round(player.time).ToString();
        GameStateManager.Instance.SendJSON(JsonUtility.ToJson(storyData));
        base.StopAndGoToScene(sceneName);
    }

}
