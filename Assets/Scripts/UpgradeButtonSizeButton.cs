using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonSizeButton : BaseButton {

    // list of buttons
    public GameObject[] buttons;
    // separate check for the sellButton
    private GameObject sellButton;

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
        // get the buttons
        buttons = GameObject.FindGameObjectsWithTag("Button");
        sellButton = GameObject.FindGameObjectWithTag("SellButton");
        
        // loop through buttons
        foreach(GameObject button in buttons)
        {
            // set the new scale
            button.transform.localScale += new Vector3(0.2f, 0.2f, 0.0f);
        }

        // set Sell Button scale
        sellButton.transform.localScale += new Vector3(0.2f, 0.2f, 0.0f);

        clearClick(); // resets the click variable
    }
}
