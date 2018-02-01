using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBase : MonoBehaviour {

    public GameObject manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            manager.GetComponent<SpawnPen>().SpawnPiece();
        }
    }
}
