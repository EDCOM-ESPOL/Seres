using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityHubManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        updateInterface(SessionManager.Instance.getPlayerScore());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateInterface(int[] playerScore)
    {

        for (int i = 0; i < playerScore.Length; ++i)
        {

            if (playerScore[i] == 0)
            {
                Debug.Log(GameObject.Find("ActivityButtonContainer").GetComponentsInChildren<Button>()[i].name);

                GameObject.Find("ActivityButtonContainer").GetComponentsInChildren<Button>()[i].gameObject.GetComponent<Image>().sprite= null;
            }
        }
    }
}
