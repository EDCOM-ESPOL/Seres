using DigitalRuby.SoundManagerNamespace;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    //private Button backButton;
    //private GameObject backButton;
    //private GameObject activityButton;
    
    //private GameObject toggler;
    public VideoPlayer player;
    public GameObject panel;
    public GameObject pauseButton;
    public GameObject playButton;
    
    

    // Use this for initialization
    void Start () {
        //Debug.Log("Player ID: " + SessionManager.Instance.getPlayerID());
        //Debug.Log("Player Avatar : " + SessionManager.Instance.getPlayerAvatarName());

        //backButton = GameObject.Find("BackButton");
        //activityButton = GameObject.Find("GoToActivityButton");


        //panel = GameObject.Find("Control Panel");

        //Debug.Log(toggler.activeSelf);
        panel.SetActive(false);
        //Debug.Log(toggler.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlaying)
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

                //Debug.Log(toggler.activeSelf);
            }
        }
        else
        {
            panel.SetActive(true);
            //pauseButton.SetActive(false);
            //playButton.SetActive(false);
        }

        //Debug.Log(player.time);

        //if (player.time >= 5f) {
        //    ShowOptions();
        //}
    }

    public void Replay()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        player.time = 0.0f;
        Debug.Log("LOLA");
        player.Stop();

        player.Play();

    }

    public void Stop()
    {
        player.Stop();
    }

    public void StopAndGoToScene(string scene)
    {
        GameStateManager.Instance.LoadScene(scene);
    }

    public void ShowOptions()
    {
        panel.SetActive(true);
    }

    public void Pause()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        player.Pause();
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void UnPause()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        player.Play();
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }



}
