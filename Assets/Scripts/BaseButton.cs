using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseButton : MonoBehaviour {

    public bool clicked;
    public float clickTimer;

	// Use this for initialization
	void Start () {
        clicked = false;
        clickTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        clickTimer += Time.deltaTime;
        if (clickTimer > 0.3f)
        {
            clicked = false;
        }
	}

    void OnMouseDown()
    {
        if (!clicked)
        {
            DoButtonAction();
            clicked = true;
            clickTimer = 0.0f;
        }
    }

    public abstract void DoButtonAction();
}
