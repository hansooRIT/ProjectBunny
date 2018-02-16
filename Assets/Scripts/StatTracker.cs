using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour {

    public static StatTracker Instance;

    public GameObject manager;

    //Stats needed to track for the GameOver scene
    public float finalDebt;
    public bool lossFromDebt;


    void Start()
    {
        finalDebt = 0f;
        lossFromDebt = false;
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
