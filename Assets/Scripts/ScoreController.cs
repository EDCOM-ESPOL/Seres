using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        //Debug.Log(GameObject.Find("ActivityController"));

        //int score = GameObject.Find("ActivityController").GetComponent<ActivityController>().GetScore();
        int index = GameObject.Find("ActivityController").GetComponent<ActivityController>().GetOrder();


        //Debug.Log("IsAlive: " + buttonClicked.GetComponent<ActivityOption>().isAlive);
        //Debug.Log(order[index]);
        //Debug.Log(System.Convert.ToBoolean(index));

        if (buttonClicked.GetComponent<ActivityOption>().isAlive == System.Convert.ToBoolean(index))
        {

            //score++;
            //GameObject.Find("ActivityController").GetComponent<ActivityController>().SetScore(score);
            //Debug.Log(score);
            //scoreText.text = score.ToString();

            //Debug.Log(SceneManager.GetActiveScene().name);

            int[] aux = SessionManager.Instance.getPlayerScore();

            switch (SceneManager.GetActiveScene().name)
            {
                case "Activity1":
                    Debug.Log("QUEPAJO");
                    aux[0] = aux[0] + 1;
                    if (aux[1] == 0)
                    {
                        aux[1] = 1;
                    }
                    break;
                default:
                    break;
            }

            SessionManager.Instance.setPlayerScore(aux);
            GameStateManager.Instance.LoadScene("ActivityHub");

            //GameObject.Find("SceneController").GetComponent<SceneController>().LoadScene("ActivityHub");
        }
        else
        {
            //buttonClicked.GetComponent<Image>().sprite = right;
        }


    }

}
