using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectController : MonoBehaviour {
   
    public GameObject ConfirmPanel;
    private Image originalAvatar;
    private Image copyAvatar;


    // Use this for initialization
    void Start () {
        
        this.GetComponent<Button>().onClick.AddListener(delegate { SelectAvatar(); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectAvatar()
    {
        //ConfirmPanel = GameObject.Find("BackButton");
        originalAvatar = this.transform.Find("Image").GetComponent<Image>();  
        copyAvatar = ConfirmPanel.transform.Find("Confirm Panel/Image").GetComponent<Image>();
        copyAvatar.sprite = originalAvatar.sprite;
        ConfirmPanel.SetActive(true);
    }

    public void CancelAvatar(GameObject avatar)
    {
        avatar.SetActive(false);
    }
}
