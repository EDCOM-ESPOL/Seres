using UnityEngine;
using UnityEngine.UI;

public class ActivityHubManager : MonoBehaviour {

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
            if (levels[i] == true)
            {
                activityButtons[i].interactable = true;
            }
            else {
                activityButtons[i].interactable = false;
            }

        }
    }
}
