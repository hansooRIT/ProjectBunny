using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBunnyButton : BaseButton {

    public GameObject manager, bunny, cam;

    public override void DoButtonAction()
    {
        GameObject newBunny = Instantiate(bunny, new Vector3(UnityEngine.Random.Range(-((cam.GetComponent<Camera>().orthographicSize * 2.0f) + 1), (cam.GetComponent<Camera>().orthographicSize * 2.0f) + 1), UnityEngine.Random.Range(-(cam.GetComponent<Camera>().orthographicSize - 0.5f), cam.GetComponent<Camera>().orthographicSize - 0.5f), 1.0f), Quaternion.identity);
        newBunny.GetComponent<AdultBunny>().cam = cam;
        newBunny.GetComponent<AdultBunny>().manager = manager;
        newBunny.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
        clearClick();
        //manager.GetComponent<Manager>().bunnyList.Add(newBunny);
        //manager.GetComponent<DebtMeter>().spendMoney();
        //Debug.Log("Current Debt: " + manager.GetComponent<DebtMeter>().getDebt());
    }
}
