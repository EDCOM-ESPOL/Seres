using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickNavigator : MonoBehaviour {

    public string sceneName;
    Button thisButton;

    // Use this for initialization
    void Start () {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(delegate { loadScene(); });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void loadScene()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        GameStateManager.Instance.LoadScene(sceneName);
    }
}
