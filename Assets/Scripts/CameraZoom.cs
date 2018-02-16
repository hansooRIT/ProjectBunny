using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : BaseButton {

    public GameObject cam;
    public GameObject background;

    //Reference to DebtMeter
    public GameObject debtManager;

    public override void DoButtonAction()
    {
        cam.GetComponent<Camera>().orthographicSize += 1;
        background.transform.localScale += new Vector3(0.5f, 0.5f, 0.0f);

        //Get DebtMeter to spend money
        debtManager = GameObject.Find("Manager");

        //Spends Money
        debtManager.GetComponent<DebtMeter>().spendMoney(5000);

        clearClick();
    }
}
