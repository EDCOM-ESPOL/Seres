using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[System.Serializable]
public class SessionManager : UnitySingleton<SessionManager> {

    //private string school = "ES001";
    //private string room = "R1";
    
    //public string PlayerAvatarName { get; set; }
    //public string PlayerName { get; set; }
    

    public string tipo = "jugador";
    public string avatar;
    public string nombre_jugador;
    public string nombre_juego = "En mi Entorno Natural";

    private string V;


    private int[] playerScore = { 0, 0, 0, 0 };

    //    {

    //  "tipo":"jugador",

    //  "avatar":"prueba",

    //  "nombre_jugador":"ES001-R1-Marco"

    //}


    //private bool[] levels = { true, true, true, true };





    public int[] getPlayerScore()
    {
        return this.playerScore;
    }

    public void setPlayerScore(int[] score)
    {
        this.playerScore = score;
    }

    public void SetPlayerInfo(string avatar, string nombre_jugador)
    {
        string school = GameStateManager.Instance.GetGlobalSettings().school;
        string room = GameStateManager.Instance.GetGlobalSettings().room;
        
if (school == "" || room == "")
        {
            V = "";
        }
        else
        {
            V = "-";
        }
        this.avatar = avatar;
        this.nombre_jugador = nombre_jugador;
        this.nombre_jugador = school + V + room + V + nombre_jugador;

        GameStateManager.Instance.AddJsonToList(JsonUtility.ToJson(this));
    }

    

    //public bool[] getLevels()
    //{
    //    return this.levels;
    //}

    //public void setLevels(bool[] levels)
    //{
    //    this.levels = levels;
    //}
}

[Serializable]
    public class GlobalSettings{
        public string school;
        public string room;
    
        public GlobalSettings()
        {
            school = "";
            room = "";
        }

        public GlobalSettings(string school, string room)
        {
            this.school = school;
            this.room = room;
        }

}
