using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickNavigator : MonoBehaviour {

    public string sceneName;
    public bool isURL;
    Button thisButton;

    // Use this for initialization
    void Start () {
        thisButton = GetComponent<Button>();
        if (isURL)
        {
            thisButton.onClick.AddListener(delegate { loadAboutURL(); });
        }else
        {
            thisButton.onClick.AddListener(delegate { loadScene(); });
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void loadScene()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        GameStateManager.Instance.LoadScene(sceneName);
    }

    void loadAboutURL()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        Application.OpenURL("http://www.espol.edu.ec");
    }
}
