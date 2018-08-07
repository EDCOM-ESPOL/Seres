using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EvaluateOnClick(Button buttonClicked)
    {
        Debug.Log(GameObject.Find("ActivityController"));

        int score = GameObject.Find("ActivityController").GetComponent<ActivityController>().GetScore();
        int index = GameObject.Find("ActivityController").GetComponent<ActivityController>().GetOrder();


        Debug.Log("IsAlive: " + buttonClicked.GetComponent<ActivityOption>().isAlive);
        //Debug.Log(order[index]);
        Debug.Log(System.Convert.ToBoolean(index));

        if (buttonClicked.GetComponent<ActivityOption>().isAlive == System.Convert.ToBoolean(index))
        {

            score++;
            GameObject.Find("ActivityController").GetComponent<ActivityController>().SetScore(score);
            Debug.Log(score);
            //scoreText.text = score.ToString();
            SessionManager.Instance.setPlayerScore( new int[] { 1,1,0,0,0});
            GameObject.Find("SceneController").GetComponent<SceneController>().LoadScene("ActivityHub");
        }
        else
        {
            //buttonClicked.GetComponent<Image>().sprite = right;
        }


    }

}
