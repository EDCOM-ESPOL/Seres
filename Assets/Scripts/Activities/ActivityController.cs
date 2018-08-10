using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityController : MonoBehaviour {

    public Sprite right;
    public Sprite wrong;
    public Text orderText;
    public Text scoreText;

    private string[] order = {"Ser No Vivo", "Ser Vivo" }; //0 = no vivo ... 1 = vivo
    //private int score;

    private int index;

    // Use this for initialization
    void Start () {
        index = Random.Range(0, 2);
        //score = 0;

        orderText.text = order[index];

        gameObject.GetComponent<SpawnActivityOption>().CreateBeing(false);
        gameObject.GetComponent<SpawnActivityOption>().CreateBeing(true);

    }
	
	// Update is called once per frame
	void Update () {
        
        
    }

    //public int GetScore()
    //{
    //    return score;
    //}

    public void SetScoreInScreen(int score)
    {
        scoreText.text = score.ToString();
    }

    public int GetOrder()
    {
        return index;
    }

}
