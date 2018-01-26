using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebtMeter : MonoBehaviour {

    public int debt;

	// Use this for initialization
	void Start () {
        debt = 0;
	}

    // Gets the player's debt
    public int getDebt()
    {
        return debt;
    }

    // Adds to the player's debt by a given amount
    public void spendMoney(int num)
    {
        debt -= num;
    }

    // Adds to the player's debt without a given amount
    public void spendMoney()
    {
        debt -= 5;
    }

    // Subtract from the player's debt by a given amount
    public void getMoney(int num)
    {
        debt += num;
    }

    // Subtract from the player's debt without a given amount
    public void getMoney()
    {
        debt += 5;
    }
}
