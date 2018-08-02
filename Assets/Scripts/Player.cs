using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ScriptableObject {

    string playerId;
    Sprite playerAvatar;
    int playerScore;
    Time playerTotalPlaytime;

	// Use this for initialization
	void Start () {
        Debug.Log(playerId);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
