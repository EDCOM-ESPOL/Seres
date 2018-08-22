using DigitalRuby.SoundManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityController : MonoBehaviour {

    //public Sprite right;
    //public Sprite wrong;
    //public Text orderText;
    //public Text scoreText;
    public GameObject activityOptionPrefab;
    public Sprite[] nonLivingSprites;
    public Sprite[] livingSprites;
    //public Color right;
    //public Color wrong;
    public Color[] myColors; //0 = white, 1 = green, 2 = red

    private int activity3Flag = 0;
    private bool activityFinished = false;


    private bool order;  //0 = no vivo ... 1 = vivo
    private string orderSoundName;  //el nombre del audio que dará la orden en esta actividad


    // Use this for initialization
    void Start () {

        int index = Random.Range(0, 2);
        if (index == 0)
        {
            order = false;
            //orderText.text = "Ser No Vivo";

            switch (GameStateManager.Instance.getCurrentSceneName())
            {
                case "Activity1":
                    orderSoundName = "LoliSenalaNoVivo";
                    break;
                case "Activity2":
                    orderSoundName = "LoliSenalaNoVivo";
                    break;
                case "Activity3":
                    orderSoundName = "LoliTodosNoVivos";
                    break;
                case "Activity4":
                    orderSoundName = "LoliEsNoVivo";
                    break;
                default:
                    break;
            }
        }
        else
        {
            order = true;
            //orderText.text = "Ser Vivo";

            switch (GameStateManager.Instance.getCurrentSceneName())
            {
                case "Activity1":
                    orderSoundName = "LoliSenalaVivo";
                    break;
                case "Activity2":
                    orderSoundName = "LoliSenalaVivo";
                    break;
                case "Activity3":
                    orderSoundName = "LoliTodosVivos";
                    break;
                case "Activity4":
                    orderSoundName = "LoliEsVivo";
                    break;
                default:
                    break;
            }
        }

        AudioManager.Instance.PlaySound(orderSoundName);


        switch (GameStateManager.Instance.getCurrentSceneName())
        {
            case "Activity1":
                SpawnBeing(false);
                SpawnBeing(true);
                break;
            case "Activity2":
                if (order)
                {
                    SpawnBeing(false);
                    SpawnBeing(true);
                    SpawnBeing(false);
                }
                else
                {
                    SpawnBeing(true);
                    SpawnBeing(false);
                    SpawnBeing(true);
                }
                break;
            case "Activity3":
                if (order)
                {
                    SpawnBeing(true);
                    SpawnBeing(false);
                    SpawnBeing(true);
                }
                else
                {
                    SpawnBeing(false);
                    SpawnBeing(true);
                    SpawnBeing(false);
                }
                break;
            case "Activity4":
                int i = Random.Range(0, 2);
                if (i == 0)
                {
                    SpawnBeing(false);
                }
                else
                {
                    SpawnBeing(true);
                }
                break;
            default:
                break;
        }



    }

    // Update is called once per frame
    void Update () {
        
        
    }

    //public int GetScore()
    //{
    //    return score;
    //}

    //public void SetScoreInScreen(int score)
    //{
    //    scoreText.text = score.ToString();
    //}

    public bool GetOrder()
    {
        return order;
    }



    public void SpawnBeing(bool isAlive)
    {
        GameObject newActivityOption = Instantiate(activityOptionPrefab);
        newActivityOption.GetComponent<ActivityOption>().isAlive = isAlive;
        ColorBlock oldCB = newActivityOption.GetComponent<Button>().colors;

        if (GameStateManager.Instance.getCurrentSceneName() != "Activity4")
        {
            if (isAlive == order)
            {
                oldCB.pressedColor = myColors[1];
            }
            else
            {
                oldCB.pressedColor = myColors[2];
            }
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

        if (GameStateManager.Instance.getCurrentSceneName() == "Activity2")
        {
            newActivityOption.transform.SetParent(GameObject.Find("Options").transform);
            newActivityOption.transform.GetChild(0).transform.localPosition = new Vector3(0f, 2f, 0f);
            newActivityOption.transform.GetChild(0).transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);

        }
        else newActivityOption.transform.SetParent(GameObject.Find("OptionPanel").transform);

        if (GameStateManager.Instance.getCurrentSceneName() == "Activity4")
        {
            newActivityOption.transform.SetAsFirstSibling();
        }else newActivityOption.GetComponent<Button>().onClick.AddListener(delegate { EvaluateOnClick(newActivityOption.GetComponent<Button>()); });

        newActivityOption.transform.localScale = new Vector3(1f, 1f, 1f);
        
    }




    public void EvaluateOnClick(Button buttonClicked)
    {

        //bool order = GameObject.Find("ActivityController").GetComponent<ActivityController>().GetOrder();

        if (buttonClicked.GetComponent<ActivityOption>().isAlive == this.GetOrder())
        {
            ColorBlock oldCB;
            int[] scores = SessionManager.Instance.getPlayerScore();
            bool[] levels = SessionManager.Instance.getLevels();

            switch (GameStateManager.Instance.getCurrentSceneName())
            {
                case "Activity1":

                    activityFinished = true;

                    scores[0] = scores[0] + 1;
                    if (levels[1] == false)
                    {
                        levels[1] = true;
                        Debug.Log("Nivel 2 Activado");
                    }
                    break;
                case "Activity2":
                    oldCB = GameObject.Find("Answer").GetComponent<Button>().colors;
                    oldCB.normalColor = myColors[1];
                    GameObject.Find("Answer").GetComponent<Button>().colors = oldCB;

                    GameObject.Find("Answer").transform.GetChild(0).GetComponent<Image>().sprite = buttonClicked.transform.GetChild(0).GetComponent<Image>().sprite;

                    activityFinished = true;

                    scores[1] = scores[1] + 1;
                    if (levels[2] == false)
                    {
                        levels[2] = true;
                        Debug.Log("Nivel 3 Activado");
                    }
                    break;
                case "Activity3":
                    oldCB = buttonClicked.colors;

                    if (buttonClicked.GetComponent<ActivityOption>().selected)
                    {
                        oldCB.normalColor = myColors[0];
                        oldCB.highlightedColor = myColors[0];
                        buttonClicked.colors = oldCB;
                        buttonClicked.GetComponent<ActivityOption>().selected = false;
                        activity3Flag = activity3Flag - 1;
                    }
                    else
                    {    
                        oldCB.normalColor = myColors[1];
                        oldCB.highlightedColor = myColors[1];
                        buttonClicked.colors = oldCB;
                        buttonClicked.GetComponent<ActivityOption>().selected = true;
                        activity3Flag = activity3Flag + 1;
                    }

                    
                    Debug.Log(activity3Flag);

                    if (activity3Flag >= 2)
                    {
                        activityFinished = true;
                        scores[2] = scores[2] + 1;
                        if (levels[3] == false)
                        {
                            levels[3] = true;
                            Debug.Log("Nivel 4 Activado");
                        }
                    }
                    
                    break;
                //case "Activity4":
                //    scores[3] = scores[3] + 1;
                //    if (levels[4] == false)
                //    {
                //        levels[4] = true;
                //        Debug.Log("Nivel 5 Activado");
                //    }
                //    break;
                default:
                    break;
            }


            if (activityFinished)
            {
                SessionManager.Instance.setPlayerScore(scores);
                SessionManager.Instance.setLevels(levels);
                //AudioManager.Instance.PlaySound("Win");
                StartCoroutine(win());
            }

        }
        else
        {
            //AudioManager.Instance.PlaySound("Lose");
            AudioManager.Instance.PlaySound("LoliDeNuevo");
        }


    }


    public void EvaluateOnClickAct4(bool answer)
    {
        //ColorBlock oldCB;
        int[] scores = SessionManager.Instance.getPlayerScore();
        bool[] levels = SessionManager.Instance.getLevels();

        bool activityOption = GameObject.Find("OptionPanel").transform.GetChild(0).GetComponent<ActivityOption>().isAlive;

        if (((order == answer) & activityOption) | ((order != answer) & !activityOption) )
        {
            Debug.Log("GANASTE");
            activityFinished = true;
            scores[3] = scores[3] + 1;
            if (levels[4] == false)
            {
                levels[4] = true;
                Debug.Log("Nivel 5 Activado");
            }

            if (activityFinished)
            {
                SessionManager.Instance.setPlayerScore(scores);
                SessionManager.Instance.setLevels(levels);
                //AudioManager.Instance.PlaySound("Win");
                StartCoroutine(win());
            }

        }
        else
        {
            Debug.Log("PERDISTE");
            AudioManager.Instance.PlaySound("LoliDeNuevo");
        }



    }



    public void ReplayOrder()
    {

        AudioManager.Instance.PlaySound(orderSoundName);

        //if (order)
        //{
        //    AudioManager.Instance.PlaySound("LoliSenalaVivo");   
        //}
        //else
        //{
        //    AudioManager.Instance.PlaySound("LoliSenalaNoVivo");
        //}
    }

    IEnumerator win()
    {
        AudioManager.Instance.PlaySound("LoliExcelente");

        yield return new WaitForSeconds(3);

        GameStateManager.Instance.LoadScene("ActivityHub");
    }
}
