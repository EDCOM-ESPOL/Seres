using DigitalRuby.SoundManagerNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ActivityHubManager : MonoBehaviour {

    private Button[] activityButtons;


    // Use this for initialization
    void Start () {
        //AudioManager.Instance.PlaySound("LoliEscogeNivel");
        activityButtons = GameObject.Find("ActivityButtonContainer").GetComponentsInChildren<Button>();
        updateInterface(SessionManager.Instance.getLevels());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateInterface(bool[] levels)
    {

        for (int i = 0; i < levels.Length; ++i)
        {
            if (levels[i] == true)
            {
                activityButtons[i].interactable = true;
            }
            else {
                activityButtons[i].interactable = false;
            }

        }
    }

    public void showExit(GameObject confirmPanelBack)
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        confirmPanelBack.SetActive(true);
    }


    public void cancelExit(GameObject confirmPanelBack)
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        confirmPanelBack.SetActive(false);
    }

    public void exitApp()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        Application.Quit();
    }
}
