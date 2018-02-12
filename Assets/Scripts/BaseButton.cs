using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseButton : MonoBehaviour
{

    public bool clicked;
    public float clickTimer;
    public Sprite buttonDown;
    public Sprite buttonUp;
    // Use this for initialization
    void Start()
    {
        clicked = false;
        clickTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // mouse button inputs
        if(Input.GetMouseButtonDown(0))
        {
            // left click, perform buy action
            // disable dragging
            this.gameObject.GetComponent<DragObject>().enabled = false;
            Debug.Log("left click");
        }
        if(Input.GetMouseButtonDown(1))
        {
            // enable dragging
            this.gameObject.GetComponent<DragObject>().enabled = true;
            Debug.Log("right click");
        }*/

        clickTimer += Time.deltaTime;
        if (clickTimer > 0.3f)
        {
            clicked = false;
        }
    }
    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = buttonDown;
    }
    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = buttonUp;
    }
    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = buttonUp;
        if (!clicked)
        {
            DoButtonAction();
            clicked = true;
            clickTimer = 0.0f;
        }
    }

    public abstract void DoButtonAction();
}
