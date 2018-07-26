using UnityEngine;

public class VideoController : MonoBehaviour {

    //private Button backButton;
    //private GameObject backButton;
    //private GameObject activityButton;
    private GameObject toggler;

    // Use this for initialization
    void Start () {
        //backButton = GameObject.Find("BackButton");
        //activityButton = GameObject.Find("GoToActivityButton");
        toggler = GameObject.Find("Control Panel");
        Debug.Log(toggler.activeSelf);
        toggler.SetActive(false);
        Debug.Log(toggler.activeSelf);
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

            Debug.Log(toggler.activeSelf);
        }
    }

    //void OnMouseDown()
    //{
    //    Debug.Log(toggler.activeSelf);
    //}


}
