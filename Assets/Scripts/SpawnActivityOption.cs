using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnActivityOption : MonoBehaviour {

    public GameObject activityOptionPrefab;
    public Sprite[] nonLivingSprites;
    public Sprite[] livingSprites;

    void Start()
    {
        
    }

    public void CreateNonLiving()
    {
        Sprite nonLivingSprite = nonLivingSprites[Random.Range(0, nonLivingSprites.Length)];
        

        GameObject newActivityOption = Instantiate (activityOptionPrefab);
        newActivityOption.name = nonLivingSprite.name;
        newActivityOption.GetComponent<ActivityOption>().isAlive = false;
        newActivityOption.GetComponent<Image>().sprite = nonLivingSprite;
        newActivityOption.transform.SetParent(GameObject.Find("OptionPanel").transform);
        newActivityOption.transform.localScale = new Vector3(1f, 1f, 1f);


    }

    public void CreateLiving()
    {
        Sprite livingSprite = livingSprites[Random.Range(0, livingSprites.Length)];
        //bool isAlive = true;
    }
}
