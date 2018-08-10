using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityController : UnitySingleton<ActivityController> {

    //public Sprite right;
    //public Sprite wrong;
    public Text orderText;
    public Text scoreText;
    public GameObject activityOptionPrefab;
    public Sprite[] nonLivingSprites;
    public Sprite[] livingSprites;
    public Color right;
    public Color wrong;



    private bool order;  //0 = no vivo ... 1 = vivo


    // Use this for initialization
    void Start () {

        int index = Random.Range(0, 2);
        if (index == 0)
        {
            order = false;
            orderText.text = "Ser No Vivo";
            AudioManager.Instance.PlaySound("LoliSenalaNoVivo");
        }
        else
        {
            order = true;
            orderText.text = "Ser Vivo";
            AudioManager.Instance.PlaySound("LoliSenalaVivo");
        }

        SpawnBeing(false);
        SpawnBeing(true);

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

    public bool GetOrder()
    {
        return order;
    }



    public void SpawnBeing(bool isAlive)
    {
        GameObject newActivityOption = Instantiate(activityOptionPrefab);
        newActivityOption.GetComponent<ActivityOption>().isAlive = isAlive;
        ColorBlock oldCB = newActivityOption.GetComponent<Button>().colors;

        if (isAlive == order)
        {
            oldCB.pressedColor = right;
        }
        else
        {
            oldCB.pressedColor = wrong;
        }

        newActivityOption.GetComponent<Button>().colors = oldCB;

        Sprite beingSprite;
        if (isAlive)
        {
            beingSprite = livingSprites[Random.Range(0, livingSprites.Length)];
        }
        else
        {
            beingSprite = nonLivingSprites[Random.Range(0, nonLivingSprites.Length)];
        }

        newActivityOption.name = beingSprite.name;
        newActivityOption.transform.GetChild(0).GetComponent<Image>().sprite = beingSprite;
        newActivityOption.transform.SetParent(GameObject.Find("OptionPanel").transform);
        newActivityOption.transform.localScale = new Vector3(1f, 1f, 1f);
        newActivityOption.GetComponent<Button>().onClick.AddListener( delegate { EvaluateOnClick(newActivityOption.GetComponent<Button>()); });
    }




    public void EvaluateOnClick(Button buttonClicked)
    {

        bool order = GameObject.Find("ActivityController").GetComponent<ActivityController>().GetOrder();

        if (buttonClicked.GetComponent<ActivityOption>().isAlive == order)
        {

            int[] scores = SessionManager.Instance.getPlayerScore();
            bool[] levels = SessionManager.Instance.getLevels();

            switch (GameStateManager.Instance.getCurrentSceneName())
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
            //AudioManager.Instance.PlaySound("Win");
            AudioManager.Instance.PlaySound("LoliExcelente");
            GameStateManager.Instance.LoadScene("ActivityHub");

        }
        else
        {
            //AudioManager.Instance.PlaySound("Lose");
            AudioManager.Instance.PlaySound("LoliDeNuevo");
        }


    }

    public void ReplayOrder()
    {
        if (order)
        {
            AudioManager.Instance.PlaySound("LoliSenalaVivo");   
        }
        else
        {
            AudioManager.Instance.PlaySound("LoliSenalaNoVivo");
        }
    }


}
