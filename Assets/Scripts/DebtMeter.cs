using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebtMeter : MonoBehaviour
{

    public float timeSinceLastSecond;
    public float money;
    public GameObject Slider;
    public GameObject displayMoney;

    // Use this for initialization
    void Start()
    {
        money = Slider.GetComponent<Slider>().value;
        timeSinceLastSecond = 0;
    }

    private void Update()
    {
        money -= 80 * Time.deltaTime;
        Slider.GetComponent<Slider>().value = money;



        timeSinceLastSecond += Time.deltaTime;

        // Only update every third of a second
        if (timeSinceLastSecond > 0.3333f)
        {
            timeSinceLastSecond = 0.0f;
            int truncatedMoney = (int)money;
            displayMoney.GetComponent<Text>().text = "Money: " + truncatedMoney;
        }

    }

    // Gets the player's money
    public float returnMoney()
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
        if (money > 49853) { } // Stop adding past a certain point
        else if (money > 49000)
        {
            money += num / 100;
        }
        else if (money > 10)
        {
            money += num * money * 0.00004f / ((money * 0.0001f) * (money * 0.0001f));
        }
        else
        {
            money += num;
        }
    }
}
