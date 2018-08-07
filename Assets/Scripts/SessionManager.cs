using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : UnitySingletonPersistent<SessionManager> {

    string playerId;
    Sprite playerAvatar;
    private int[] playerScore = { 1,0,0,0,0};

    // Use this for initialization
    void Start () {
        setPlayerID();
        Debug.Log(playerId);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setPlayerID()
    {
        this.playerId = Random.Range(0, 100).ToString();
    }

    public void setPlayerAvatar(Sprite sprite)
    {
        this.playerAvatar = sprite;
    }

    public int[] getPlayerScore()
    {
        return this.playerScore;
    }

    public void setPlayerScore(int[] score)
    {
        this.playerScore = score;
    }
}
