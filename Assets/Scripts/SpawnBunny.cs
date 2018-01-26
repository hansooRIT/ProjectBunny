using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnBunny : MonoBehaviour {

    public GameObject manager, bunny;
    public Button spawnBunnyButton;
    
    // Use this for initialization
    void Start () {
        Button btn = spawnBunnyButton.GetComponent<Button>();
        btn.onClick.AddListener(spawnBunny);
    }

    void spawnBunny()
    {
        GameObject newBunny = Instantiate(bunny, new Vector3(UnityEngine.Random.Range(-4.0f, -25.0f), UnityEngine.Random.Range(-3.0f, 3.0f), 0.0f), Quaternion.identity);
        manager.GetComponent<Manager>().bunnyList.Add(newBunny);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
