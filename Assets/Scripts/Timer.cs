using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public GameObject CanvasObject;
    public int currentMinutes;
    public float currentSeconds;
    private bool minuteCheck;
    public DebtMeter other;

    // Use this for initialization
    void Start ()
    {
        currentSeconds = 0;
        currentMinutes = 0;
        minuteCheck = true;
    }
	
	// Update is called once per frame
	void Update () {
        currentSeconds += Time.deltaTime;

        // 60 seconds turns into 0 seconds and 1 minute
        if(currentSeconds >= 60.0f)
        {
            currentMinutes++;
            //If 10 minutes is reached, send to the GameOver scene
            if(currentMinutes >= 10)
            {
                SceneManager.LoadScene("Victory");
            }

            currentSeconds = 0;

            // Check if 2 minutes have passed
            minuteCheck = !minuteCheck;
            
            // Call the increase max debt method every 2 minutes
            if (minuteCheck)
            {
                other.increaseMaxDebt(10000);
            }
        }

        // Change from a float to an int to be readable
        int truncatedSeconds = (int)currentSeconds;
        if(truncatedSeconds < 10)
        {
            // need a 0 before a single digit
            CanvasObject.transform.Find("TimerText").GetComponent<Text>().text = "        Play Time: " + currentMinutes + ":0" + truncatedSeconds + " / 10:00";
        }
        else
        {
            CanvasObject.transform.Find("TimerText").GetComponent<Text>().text = "        Play Time: " + currentMinutes + ":" + truncatedSeconds + " / 10:00";
        }
    }
}
