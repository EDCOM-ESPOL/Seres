using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnActivityOption : MonoBehaviour
{

    public GameObject activityOptionPrefab;
    public Sprite[] nonLivingSprites;
    public Sprite[] livingSprites;

    void Start()
    {

    }

    public void CreateBeing(bool isAlive)
    {
        Sprite beingSprite;
        if (isAlive)
        {
            beingSprite = livingSprites[Random.Range(0, livingSprites.Length)];
        }
        else
        {
            beingSprite = nonLivingSprites[Random.Range(0, nonLivingSprites.Length)];
        }

        GameObject newActivityOption = Instantiate(activityOptionPrefab);
        newActivityOption.name = beingSprite.name;
        newActivityOption.GetComponent<ActivityOption>().isAlive = isAlive;
        newActivityOption.GetComponent<Image>().sprite = beingSprite;
        newActivityOption.transform.SetParent(GameObject.Find("OptionPanel").transform);
        newActivityOption.transform.localScale = new Vector3(1f, 1f, 1f);

    }

}
