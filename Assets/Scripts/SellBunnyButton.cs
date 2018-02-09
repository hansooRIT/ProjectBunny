using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBunnyButton : MonoBehaviour {

    public GameObject manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "AdultBunny")
        {
            //Code for gaining money and deleting bunny;
            Debug.Log("Sold adult bunny");
        }
        else if (c.gameObject.tag == "Baby")
        {

        }
    }
}
