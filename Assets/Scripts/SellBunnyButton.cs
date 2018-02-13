using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellBunnyButton : MonoBehaviour {

    public GameObject manager;

	// Use this for initialization
	void Start () {
        Button sellButton = this.GetComponent<Button>();
        sellButton.onClick.AddListener(DeleteNearestBunny);
	}
	
    // Deletes the nearest bunny
    void DeleteNearestBunny()
    {
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
