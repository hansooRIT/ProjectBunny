using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPen : MonoBehaviour {

    public GameObject penPieceImg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPiece()
    {
        GameObject temp = Instantiate(penPieceImg, new Vector3(Input.mousePosition.x,Input.mousePosition.y,0.0f), Quaternion.identity);
        //temp.transform.localScale = new Vector3(100.0f, 100.0f, 1.0f);
    }
}
