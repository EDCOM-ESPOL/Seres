using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionManager : UnitySingletonPersistent<SessionManager> {

    private string playerId;
    private Sprite playerAvatar;
    private int[] playerScore = { 1,0,0,0,0};

    // Use this for initialization
    void Start () {
        setPlayerID();
        Debug.Log(playerId);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public string getPlayerID()
    {
        return this.playerId;
    }

    public void setPlayerID()
    {
        this.playerId = Random.Range(0, 100).ToString();
    }


    public Sprite getPlayerAvatar()
    {
        return this.playerAvatar;
    }

    public void setPlayerAvatar(Sprite avatarSprite)
    {
        this.playerAvatar = avatarSprite;
    }

    public string getPlayerAvatarName()
    {
        return this.playerAvatar.name;
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
