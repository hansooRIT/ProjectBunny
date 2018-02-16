using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseButton : MonoBehaviour
{

    public bool clicked , bunnyClicked;
    public float clickTimer, bunnyClickTimer;
    public Sprite buttonDown;
    public Sprite buttonUp;
    // Use this for initialization
    void Start()
    {
        clicked = false;
        bunnyClicked = false;
        clickTimer = 0.0f;
        bunnyClickTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        clickTimer += Time.deltaTime;
        bunnyClickTimer += Time.deltaTime;
        if (clickTimer > 0.3f)
        {
            clicked = false;
        }
        if (bunnyClickTimer > 2.5f)
        {
            bunnyClicked = false;
        }
    }
    public void OnMouseDown()
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
            clearClick();
        }
    }

    public void clearClick()
    {
        clicked = true;
        clickTimer = 0.0f;
    }

    public void clearBunnyClick()
    {
        bunnyClickTimer = 0.0f;
        bunnyClicked = true;
    }

    public abstract void DoButtonAction();
}
