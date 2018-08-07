﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelectController : UnitySingleton<AvatarSelectController> {

    //public GameObject[] buttons;

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
        Image originalAvatar = button.transform.Find("Image").GetComponent<Image>();  
        selectedAvatar = ConfirmPanelBack.transform.Find("Confirm Panel/Image").GetComponent<Image>();
        selectedAvatar.sprite = originalAvatar.sprite;
        ConfirmPanelBack.SetActive(true);
    }

    public void clickCancelAvatar()
    {
        selectedAvatar = null;
        ConfirmPanelBack.SetActive(false);
    }

    public void clickConfirmAvatar()
    {
        SessionManager.Instance.setPlayerAvatar(selectedAvatar.sprite);
        GameStateManager.Instance.LoadScene("Story");
    }
}
