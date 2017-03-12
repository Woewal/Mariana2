using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public Submarine submarine;
    public static LevelController instance;

	// Use this for initialization
	void Awake () {
        instance = this;
	}
}
