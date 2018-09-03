using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum SFXOption
//{
//    Default = 0,
//    Win = 1,
//    Lose = 2
//}

public class ButtonClickNavigator : MonoBehaviour {

    public string sceneName;
    public bool isURL;
    Button thisButton;

    //public SFXOption sfx;

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
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        GameStateManager.Instance.LoadScene(sceneName);
    }

    void loadAboutURL()
    {
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        Application.OpenURL("http://www.espol.edu.ec");
    }
}
