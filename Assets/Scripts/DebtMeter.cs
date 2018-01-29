using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebtMeter : MonoBehaviour {

    public float debt;
    public GameObject Slider;

	// Use this for initialization
	void Start () {
        debt = Slider.GetComponent<Slider>().value;
    }

    private void Update()
    {
        Slider.GetComponent<Slider>().value = debt;
    }

    // Gets the player's debt
    public float getDebt()
    {
        return debt;
    }

    // Adds to the player's debt by a given amount
    public void spendMoney(float num)
    {
        debt += num;
    }

    // Adds to the player's debt without a given amount
    public void spendMoney()
    {
        debt += 50;
    }

    // Subtract from the player's debt by a given amount
    public void getMoney(float num)
    {
        debt -= num;
    }

    // Subtract from the player's debt without a given amount
    public void getMoney()
    {
        debt -= 50;
    }
}
