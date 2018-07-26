using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SelectAvatar(GameObject avatar)
    {
        avatar.SetActive(true);
    }

    public void CancelAvatar(GameObject avatar)
    {
        avatar.SetActive(false);
    }
}
