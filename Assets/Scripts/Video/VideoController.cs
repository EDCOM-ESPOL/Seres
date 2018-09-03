using DigitalRuby.SoundManagerNamespace;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    public VideoPlayer player;
    public GameObject panel;
    
    

    // Use this for initialization
    void Start () {
        
        panel.SetActive(false);
        
    }
    

    public void Replay()
    {
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        GameStateManager.Instance.ReloadCurrentScene();      
    }

    public void Stop()
    {
        player.Stop();
    }

    public void StopAndGoToScene(string scene)
    {
        GameStateManager.Instance.LoadScene(scene);
    }

    public void ShowOptions()
    {
        panel.SetActive(true);
    }

    



}
