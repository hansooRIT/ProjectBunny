using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject CanvasObject;
    public float currentPlayTime;

    // Use this for initialization
    void Start () {
        currentPlayTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentPlayTime += Time.deltaTime;
        int truncatedPlayTime = (int)currentPlayTime;
        CanvasObject.transform.Find("TimerText").GetComponent<Text>().text = "        Play Time: " + truncatedPlayTime;
    }
}
