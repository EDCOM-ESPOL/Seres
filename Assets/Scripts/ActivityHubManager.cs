using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActivityHubManager : MonoBehaviour {

    public Sprite[] colorButtons;
    public Sprite[] greyButtons;
    private Button[] activityButtons;


    // Use this for initialization
    void Start () {
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
            //Debug.Log(levels[i]);
            if (levels[i] == true)
            {
                //Debug.Log(GameObject.Find("ActivityButtonContainer").GetComponentsInChildren<Button>()[i].name);

                activityButtons[i].gameObject.GetComponent<Image>().sprite = colorButtons[i];
                int index = i;
                activityButtons[i].onClick.AddListener(delegate { ClickToActivity(index); } );
            }
            else {
                activityButtons[i].gameObject.GetComponent<Image>().sprite = greyButtons[i];
                activityButtons[i].onClick.RemoveAllListeners();
            }
            //GameObject.Find("ActivityButtonContainer").GetComponentsInChildren<Button>()[i].onClick.AddListener(() => ClickToActivity(i));

        }
    }

    private void ClickToActivity(int scene)
    {
        GameStateManager.Instance.LoadScene("Activity" + (scene+1).ToString());
    }
}
