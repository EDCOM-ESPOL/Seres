using DigitalRuby.SoundManagerNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelectController : UnitySingleton<AvatarSelectController> {

    public GameObject ConfirmPanelBack;
    private Image selectedAvatar;


    // Use this for initialization
    void Start () {
        AudioManager.Instance.PlayVoice("LoliEscogeAvatar");
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ClickSelectAvatar(GameObject button)
    {
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        Image originalAvatar = button.transform.Find("Image").GetComponent<Image>();  
        selectedAvatar = ConfirmPanelBack.transform.Find("Confirm Panel/Image").GetComponent<Image>();
        selectedAvatar.sprite = originalAvatar.sprite;
        ConfirmPanelBack.SetActive(true);
    }

    public void ClickCancelAvatar()
    {
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        selectedAvatar = null;
        ConfirmPanelBack.SetActive(false);
    }

    public void ClickConfirmAvatar()
    {
        AudioManager.Instance.PlaySFX("TinyButtonPush");
        SessionManager.Instance.setPlayerAvatar(selectedAvatar.sprite);
        GameStateManager.Instance.LoadScene("Story");
    }
}
