using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public List<GameObject> bunnyList;
    public float timeLeft = 3600f; //30 Minutes?

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;

        if(timeLeft < 0)
        {
            //Insert Game Over function call
        }

        //Debug.Log("Countdown: " + timeLeft);

	}

    void SpawnBunny()
    {

    }
}
