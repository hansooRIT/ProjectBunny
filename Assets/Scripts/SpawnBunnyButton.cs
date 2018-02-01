using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBunnyButton : BaseButton {

    public GameObject manager, bunny;

    public override void DoButtonAction()
    {
        GameObject newBunny = Instantiate(bunny, new Vector3(UnityEngine.Random.Range(-4.0f, -25.0f), UnityEngine.Random.Range(-3.0f, 3.0f), 0.0f), Quaternion.identity);
        Debug.Log("Clicked UI Button");
        //manager.GetComponent<Manager>().bunnyList.Add(newBunny);
        //manager.GetComponent<DebtMeter>().spendMoney();
        //Debug.Log("Current Debt: " + manager.GetComponent<DebtMeter>().getDebt());
    }
}
