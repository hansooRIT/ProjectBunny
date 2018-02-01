using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bunny")
        {
            Debug.Log("bunny hit the damn fence");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bunny")
        {
            Debug.Log("bunny hit fence");
        }
    }
}
