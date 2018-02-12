using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebtMeter : MonoBehaviour {

    public float money;
    public GameObject Slider;
    public GameObject displayMoney;

	// Use this for initialization
	void Start () {
        money = Slider.GetComponent<Slider>().value;
    }

    private void Update()
    {
        //money += 500 * Time.deltaTime;
        getMoney();
        Debug.Log(money);
        Slider.GetComponent<Slider>().value = money;

        int truncatedMoney = (int)money;
        displayMoney.GetComponent<Text>().text = "Money: " + truncatedMoney;
    }

    // Gets the player's money
    public float getmoney()
    {
        return money;
    }

    // Adds to the player's money by a given amount
    public void spendMoney(float num)
    {
        money -= num;
    }

    // Adds to the player's money without a given amount
    public void spendMoney()
    {
        money -= 2500;
    }

    // Subtract from the player's money by a given amount
    public void getMoney(float num)
    {
        money += num;
    }

    // Subtract from the player's money without a given amount
    public void getMoney()
    {
        int num = 500;
        if(money > 49900){} // don't do anything here
        else if(money > 49500)
        {
            money += 1;
        }
        else if(money > 45000)
        {
            money += num * 0.5f;
        }
        else if(money > 30000)
        {
            money += num / (money * 0.01f);
        }
        else
        {
            money += num;
        }
    }
}
