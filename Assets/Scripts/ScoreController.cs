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

        int index = GameObject.Find("ActivityController").GetComponent<ActivityController>().GetOrder();

        if (buttonClicked.GetComponent<ActivityOption>().isAlive == System.Convert.ToBoolean(index))
        {

            int[] scores = SessionManager.Instance.getPlayerScore();
            bool[] levels = SessionManager.Instance.getLevels();

            switch (SceneManager.GetActiveScene().name)
            {
                case "Activity1":
                    scores[0] = scores[0] + 1;
                    if (levels[1] == false)
                    {
                        levels[1] = true;
                        Debug.Log("Nivel 2 Activado");
                    }
                    break;
                case "Activity2":
                    scores[1] = scores[1] + 1;
                    if (levels[2] == false)
                    {
                        levels[2] = true;
                        Debug.Log("Nivel 3 Activado");
                    }
                    break;
                default:
                    break;
            }

            SessionManager.Instance.setPlayerScore(scores);
            SessionManager.Instance.setLevels(levels);
            GameStateManager.Instance.LoadScene("ActivityHub");
           
        }
        else
        {
            //buttonClicked.GetComponent<Image>().sprite = right;
        }


    }

}
