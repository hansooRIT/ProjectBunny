using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBunny : Bunny {

    public GameObject adultPrefab;
    float growthTimer;

	// Use this for initialization
	void Start () {
        worth = 200.0f;
        growthTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        growthTimer += Time.deltaTime;
        if (growthTimer >= 15.0f)
        {
            GameObject newBunny = Instantiate(adultPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.0f), Quaternion.identity);
            newBunny.GetComponent<Bunny>().cam = cam;
            newBunny.GetComponent<AdultBunny>().manager = manager;
            manager.GetComponent<Manager>().bunnyList.Add(newBunny);
            Destroy(gameObject);
        }
        UpdatePosition();
        CalcSteeringForces();
        FindNearestButton();
    }
}
