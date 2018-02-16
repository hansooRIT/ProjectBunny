using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebtMeter : MonoBehaviour
{

    public float timeSinceLastSecond;
    public float money;
    public float maxDebt;
    public GameObject Slider;
    public GameObject displayMoney;
    public GameObject minText;
    //public GameObject tracker;

    // Use this for initialization
    void Start()
    {
        money = Slider.GetComponent<Slider>().value;
        timeSinceLastSecond = 0;

        maxDebt = 50000f;

        //tracker = GameObject.Find("Tracker");
    }

    private void Update()
    {
        money -= 25 * Time.deltaTime;
        Slider.GetComponent<Slider>().value = money;



        timeSinceLastSecond += Time.deltaTime;

        // Only update every third of a second
        if (timeSinceLastSecond > 1.0f)
        {
            timeSinceLastSecond = 0.0f;
            int truncatedMoney = (int)money;
            displayMoney.GetComponent<Text>().text = "Money: " + truncatedMoney;
        }

        //If the maximum debt is reached, send to the GameOver scene
        if(money < (maxDebt * -1f))
        {

            //tracker.GetComponent<StatTracker>().lossFromDebt = true;
            //tracker.GetComponent<StatTracker>().finalDebt = money;

            SceneManager.LoadScene("GameOver");
        }

        //Debug.Log("Money " + money);
        //Debug.Log("maxDebt " + maxDebt);
    }

    // Gets the player's money
    public float returnMoney()
    {
        return money;
    }

    // Increases the max debt
    public void increaseMaxDebt(int increase)
    {
        maxDebt += increase;

        Slider.GetComponent<Slider>().minValue -= increase;

        minText.GetComponent<Text>().text = "$" + Slider.GetComponent<Slider>().minValue.ToString();
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
