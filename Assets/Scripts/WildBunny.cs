using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBunny : Bunny {

    public GameObject bunny;

	// Use this for initialization
	void Start () {
        worth = -50.0f;	
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition();
        CalcSteeringForces();
        FindNearestButton();
    }

    void OnMouseDown()
    {
        GameObject newBunny = Instantiate(bunny, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.0f), Quaternion.identity);
        newBunny.GetComponent<Bunny>().cam = cam;
        newBunny.GetComponent<Bunny>().manager = manager;
        manager.GetComponent<Manager>().bunnyList.Add(newBunny);
        Destroy(gameObject);
    }
}
