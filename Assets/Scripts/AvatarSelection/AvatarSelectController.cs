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
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void clickSelectAvatar(GameObject button)
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        Image originalAvatar = button.transform.Find("Image").GetComponent<Image>();  
        selectedAvatar = ConfirmPanelBack.transform.Find("Confirm Panel/Image").GetComponent<Image>();
        selectedAvatar.sprite = originalAvatar.sprite;
        ConfirmPanelBack.SetActive(true);
    }

    public void clickCancelAvatar()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        selectedAvatar = null;
        ConfirmPanelBack.SetActive(false);
    }

    public void clickConfirmAvatar()
    {
        AudioManager.Instance.PlaySound("TinyButtonPush");
        SessionManager.Instance.setPlayerAvatar(selectedAvatar.sprite);
        GameStateManager.Instance.LoadScene("Story");
    }
}
