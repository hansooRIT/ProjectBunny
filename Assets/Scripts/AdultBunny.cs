using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultBunny : Bunny {

    public bool canBreed;
    public float breedTimer;
    public GameObject childBunny;

	// Use this for initialization
	void Start(){
        worth = 100.0f;
        canBreed = false;
        breedTimer = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		breedTimer += Time.deltaTime;
        if (breedTimer > 10.0)
        {
            canBreed = true;
        }
        UpdatePosition();
        CalcSteeringForces();
        FindNearestButton();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colliding");
        if (col.gameObject.tag == "AdultBunny" && canBreed)
        {
            GameObject newBunny = Instantiate(childBunny, new Vector3(UnityEngine.Random.Range(gameObject.transform.position.x - 1.0f, gameObject.transform.position.x + 1.0f), UnityEngine.Random.Range(gameObject.transform.position.y - 1, gameObject.transform.position.y + 1), 0.0f), Quaternion.identity);
            newBunny.GetComponent<Bunny>().cam = cam;
            canBreed = false;
            breedTimer = 0.0f;
        }
    }
}
