using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceButton : BaseButton {

    public GameObject manager;
    public GameObject penPieceImg;

    /*
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
    */
    public override void DoButtonAction()
    {
        //Debug.Log("clicked fence button");
        // instantiate a fence piece
        GameObject temp = Instantiate(penPieceImg, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.0f), Quaternion.identity);
        // add to the list of fences in the manager
        manager.GetComponent<Manager>().fenceList.Add(temp);
        // add to the debt
        manager.GetComponent<DebtMeter>().spendMoney(100);
        clearClick(); // resets the click variable
    }
}
