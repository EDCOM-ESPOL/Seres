using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : UnitySingleton<GameStateManager> {

    private int sceneIndex;

    // Use this for initialization
    void Start () {
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //public void GoBack()
    //{
    //    int index = getCurrentSceneIndex();
    //    if (index < 1)
    //    {
    //        Application.Quit();
    //    }
    //    else
    //    {
    //        SceneManager.LoadScene(index - 1);
    //    }
    //}

    public int getCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public string getCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
