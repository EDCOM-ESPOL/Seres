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
    private int score = 0;
    


    // Use this for initialization
    void Start () {
        scoreText.text = score.ToString();
        int index = Random.Range(0, 2);
        orderText.text = order[index];

        gameObject.GetComponent<SpawnActivityOption>().CreateNonLiving();

	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
        
    }

    public void EvaluateOnClick(Button buttonClicked)
    {
        buttonClicked.GetComponent<Image>().sprite = right;
        score++;
        scoreText.text = score.ToString();
    }
}
