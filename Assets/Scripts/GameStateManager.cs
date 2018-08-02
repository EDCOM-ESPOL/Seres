using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : UnitySingletonPersistent<GameStateManager> {

    private int sceneIndex;
    // Use this for initialization
    void Start () {
        //SceneManager.LoadScene("Character");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
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
}
