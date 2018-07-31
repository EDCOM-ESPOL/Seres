using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    //private Button backButton;
    //private GameObject backButton;
    //private GameObject activityButton;
    private GameObject toggler;
    public VideoPlayer player; 

    // Use this for initialization
    void Start () {
        //backButton = GameObject.Find("BackButton");
        //activityButton = GameObject.Find("GoToActivityButton");
        toggler = GameObject.Find("Control Panel");
        //Debug.Log(toggler.activeSelf);
        toggler.SetActive(false);
        //Debug.Log(toggler.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (toggler.activeSelf == false)
            {
                toggler.SetActive(true);
            }
            else
            {
                toggler.SetActive(false);
            }

            //Debug.Log(toggler.activeSelf);
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


}
