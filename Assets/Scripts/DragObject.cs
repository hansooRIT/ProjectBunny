using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);

        // if dragging a bunny, disable the collider temporarily
        if(gameObject.tag == "AdultBunny" || gameObject.tag == "bunny" || gameObject.tag == "WildBunny")
        {
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        if (gameObject.tag == "Fence")
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnMouseUp()
    {
        //re-enable the collider when no longer dragging
        if (gameObject.tag == "AdultBunny" || gameObject.tag == "bunny" || gameObject.tag == "WildBunny")
        {
            this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        if (gameObject.tag == "Fence")
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
