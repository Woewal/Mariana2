using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;






public class globalFlock : MonoBehaviour {

    public GameObject fishPrefab;
    public static int tankSize = 20; 

    static int numFish = 20;

    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;

    // Use this for initialization
    void Start () {
        System.Diagnostics.Trace.WriteLine("Start");
        for (int i = 0; i < numFish; i++)
        {
            System.Diagnostics.Trace.WriteLine("whatever");
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
                                      Random.Range(-tankSize, tankSize),
                                      Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject) Instantiate(fishPrefab, pos , Quaternion.identity); 
        }
	}
	
	// Update is called once per frame
	void Update () {

        //Reset goal position
		if(Random.Range(0,10000)<50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                                  Random.Range(-tankSize, tankSize),
                                  Random.Range(-tankSize, tankSize));
        }
	}
}
