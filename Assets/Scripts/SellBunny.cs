using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBunny : MonoBehaviour {

    public GameObject manager;

    // Use this for initialization
    void Start () {
		
	}
	
    public void DeleteBunny()
    {
        manager.GetComponent<DebtMeter>().getMoney(500);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
