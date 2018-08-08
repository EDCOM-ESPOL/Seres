using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    //private Button backButton;
    //private GameObject backButton;
    //private GameObject activityButton;
    
    //private GameObject toggler;
    public VideoPlayer player;
    public GameObject panel;

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

        Debug.Log(player.time);

        if (player.time >= 5f) {
            ShowOptions();
        }
    }

    public void Replay()
    {
        player.time = 0;
        player.Play();

    }

    public void Stop()
    {
        player.time = 0;
        player.Pause();
    }

    public void StopAndGoToScene(string scene)
    {
        GameStateManager.Instance.LoadScene(scene);
    }

    public void ShowOptions()
    {
        panel.SetActive(true);
    }

}
