using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DigitalRuby.SoundManagerNamespace;

public class DDOL : UnitySingletonPersistent<DDOL> {

    // Use this for initialization
	void Start () {
        GameStateManager.Instance.LoadScene("MainScreen");
    }

}
