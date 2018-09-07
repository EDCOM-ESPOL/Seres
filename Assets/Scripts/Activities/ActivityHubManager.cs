using DigitalRuby.SoundManagerNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ActivityHubManager : MonoBehaviour {

    private Button[] activityButtons;


    // Use this for initialization
    void Start () {
        AudioManager.Instance.PlayVoice("LoliEscogeNivel");
        AudioManager.Instance.PlayMusic("BGM");
        activityButtons = GameObject.Find("ActivityButtonContainer").GetComponentsInChildren<Button>();
        //updateInterface(SessionManager.Instance.getLevels());
        
	}

    public void showExit(GameObject confirmPanelBack)
    {
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        AudioManager.Instance.PlayVoice("LoliSeguroSalir");
        confirmPanelBack.SetActive(true);
    }


    public void cancelExit(GameObject confirmPanelBack)
    {
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        AudioManager.Instance.StopAllVoices();
        confirmPanelBack.SetActive(false);
    }

    public void exitApp()
    {
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        Application.Quit();
    }
}
