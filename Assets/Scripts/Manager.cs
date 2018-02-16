using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public List<GameObject> bunnyList;
    public List<GameObject> fenceList;
    public List<GameObject> buttonList;
    //public float timeLeft = 1200f; //10 Minutes?
    float spawnTimer = 0.0f;

    public GameObject wildBunny, cam, debt;
    public bool repellant;

	// Use this for initialization
	void Start () {
        repellant = false;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            //Send the play to the GameOver scene
            SceneManager.LoadScene("GameOver");
        }
        */

        spawnTimer += Time.deltaTime;
        if (bunnyList.Count > 50)
        {
            if (spawnTimer > 1)
            {
                SpawnBunny();
                spawnTimer = 0.0f;
            }
        }
        else
        {
            if (spawnTimer > 5 - (1 * (bunnyList.Count / 10)))
            {
                SpawnBunny();
                spawnTimer = 0.0f;
            }
        }
       if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            repellant = true;
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
       else
        {
            repellant = false;
        }

        //Debug.Log("Countdown: " + timeLeft);

	}

    void SpawnBunny()
    {
        int random = Random.Range(1, 4);
        if (random == 1)
        {
            GameObject newBunny = Instantiate(wildBunny, new Vector3(-(cam.GetComponent<Camera>().orthographicSize * 3.0f), UnityEngine.Random.Range(-(cam.GetComponent<Camera>().orthographicSize - 0.5f), cam.GetComponent<Camera>().orthographicSize - 0.5f), 1.0f), Quaternion.identity);
            newBunny.GetComponent<Bunny>().cam = cam;
            newBunny.GetComponent<Bunny>().manager = gameObject;
            bunnyList.Add(newBunny);
        }
        else if (random == 2)
        {
            GameObject newBunny = Instantiate(wildBunny, new Vector3((cam.GetComponent<Camera>().orthographicSize * 3.0f), UnityEngine.Random.Range(-(cam.GetComponent<Camera>().orthographicSize - 0.5f), cam.GetComponent<Camera>().orthographicSize - 0.5f), 1.0f), Quaternion.identity);
            newBunny.GetComponent<Bunny>().cam = cam;
            newBunny.GetComponent<Bunny>().manager = gameObject;
            bunnyList.Add(newBunny);
        }
        else if (random == 3)
        {
            GameObject newBunny = Instantiate(wildBunny, new Vector3(UnityEngine.Random.Range(-((cam.GetComponent<Camera>().orthographicSize * 2.0f) + 1), (cam.GetComponent<Camera>().orthographicSize * 2.0f) + 1), (cam.GetComponent<Camera>().orthographicSize * 1.5f), 1.0f), Quaternion.identity);
            newBunny.GetComponent<Bunny>().cam = cam;
            newBunny.GetComponent<Bunny>().manager = gameObject;
            bunnyList.Add(newBunny);
        }
        else
        {
            GameObject newBunny = Instantiate(wildBunny, new Vector3(UnityEngine.Random.Range(-((cam.GetComponent<Camera>().orthographicSize * 2.0f) + 1), (cam.GetComponent<Camera>().orthographicSize * 2.0f) + 1), -(cam.GetComponent<Camera>().orthographicSize * 1.5f), 1.0f), Quaternion.identity);
            newBunny.GetComponent<Bunny>().cam = cam;
            newBunny.GetComponent<Bunny>().manager = gameObject;
            bunnyList.Add(newBunny);
        }
    }
}
