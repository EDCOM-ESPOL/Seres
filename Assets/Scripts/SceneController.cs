using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    //public static SceneController Instance;

    private int sceneIndex;

    // Use this for initialization
    void Start () {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
            
	}

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoBack()
    {
        if (sceneIndex < 1)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(sceneIndex - 1);
        }
    }

    public void CancelAvatar(GameObject avatar)
    {
        avatar.SetActive(false);
    }

}
