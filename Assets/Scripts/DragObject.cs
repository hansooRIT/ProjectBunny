using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    // disable the collider on click
    private void OnMouseDown()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Debug.Log("OnMOuseDrag");
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);

        // disable the rigidbody while dragging
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnMouseUp()
    {
        // re-enable the collider
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
