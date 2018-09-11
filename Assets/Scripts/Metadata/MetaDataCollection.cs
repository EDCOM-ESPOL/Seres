using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MetaDataCollection : UnitySingleton<MetaDataCollection> {

    public string[] localJSON;  //JSON que no han podido ser enviados debido a un error de conexión

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
