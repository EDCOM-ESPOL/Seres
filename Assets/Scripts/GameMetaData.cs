using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GameMetaData {

    public string tipo;
    public string id_registro;

    public string nombre_juego;
    public string descripcion_juego;
    public string nombre_capitulo;
    public string descripcion_capitulo;
    public string nombre_historia;

    public string fecha_inicio;         //":"2018/01/31",
    public string fecha_fin;            //":"2018/01/31",

    public string tiempo_juego;         //en segundos
    public string estado;               //completado o abandonado


    public GameMetaData(string id_registro)
    {
        this.id_registro = id_registro;

        nombre_juego = "En mi Entorno Natural";
        descripcion_juego = "bla bla";
        nombre_capitulo = "Los Seres";
        descripcion_capitulo = "bla bla";
        nombre_historia = "Historia-Seres";

        fecha_inicio = System.DateTime.Now.ToString("yyyy/MM/dd");

        estado = "abandonado";
    }

}


//{

//  "tipo":"jugador",

//  "avatar":"prueba",

//  "nombre_jugador":"ES001-R1-Marco"

//}

 

//{

//  JUEGO

//  

//  "nombre_nivel":"Seres-Nivel-1",

//  "descripcion_nivel":"Sigue las instrucciones que te da la Loly",

//  "fecha_inicio":"2018/01/31",

//  "fecha_fin":"2018/01/31",

//  "correctas":"18",

//  "incorrectas":"4",

//  "tiempo_juego":"200",

//  "estado":"completado"

//}

 

//{

//  HISTORIA

//  "descripcion_historia":"bla bla",

//  "fecha_inicio":"2018/01/31",

//  "fecha_fin":"2018/01/31",

//  "duracion":"180",

//  "tiempo_juego":"150",

//  "estado":"completado"

//}