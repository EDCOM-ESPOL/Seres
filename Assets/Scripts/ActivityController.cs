using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityController : MonoBehaviour {

    public Sprite right;
    public Sprite wrong;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EvaluateOnClick(Button buttonClicked)
    {
        buttonClicked.GetComponent<Image>().sprite = right;
    }
}
