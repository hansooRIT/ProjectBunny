using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePen : BaseButton {

    public GameObject manager;
    public GameObject penPieceImg;
    private int penSize = 5;
    private Vector3 tempLocation;
    private float imgSize = 0.5f;
    public Vector3 screenCenter;
    public List<GameObject> fences;

    // Use this for initialization
    void Start ()
    {
        // get the img size
        //imgSize = penPieceImg.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit/100f;
        // get the screen center
        screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f));
        // call the basicPen function
        basicPen();
    }
	


    public override void DoButtonAction()
    {
        upgradePenSize();
        clearClick();
    }

    public void upgradePenSize()
    {
        // increment the pen size
        penSize++;
        // delete the previous pen pieces
        foreach(GameObject fence in fences)
        {
            if(fence != null)
            {
                Destroy(fence);
            }
        }

        // recalculate the new pen based on the new size
        basicPen();
    }

    // create a starting pen that can be upgraded in size
    public void basicPen()
    {
        // spawn the pieces based on the size and around the center of the screen
        for (int i = 0; i < penSize; i++)
        {
            for (int j = 0; j < penSize; j++)
            {
                tempLocation = new Vector3(i * imgSize + (screenCenter.x -3.0f), j * imgSize + (screenCenter.y-3.0f), 0.0f);
                //Instantiate(penPieceImg, tempLocation, Quaternion.identity);
                // check to see if we are at an edge where we actually want to spawn a wall
                if (i % penSize == 0)
                {
                    // add to the debt and create a piece
                    manager.GetComponent<DebtMeter>().spendMoney(500);
                    GameObject tempFence = Instantiate(penPieceImg, tempLocation, Quaternion.identity);
                    // add to list
                    fences.Add(tempFence);
                }
                if (i % penSize == penSize - 1)
                {
                    // add to the debt and create a piece
                    manager.GetComponent<DebtMeter>().spendMoney(500);
                    GameObject tempFence = Instantiate(penPieceImg, tempLocation, Quaternion.identity);
                    // add to list
                    fences.Add(tempFence);
                }
                if (j % penSize == penSize - 1 && i > 0 && i < penSize - 1)
                {
                    // add to the debt and create a piece
                    manager.GetComponent<DebtMeter>().spendMoney(500);
                    GameObject tempFence = Instantiate(penPieceImg, tempLocation, Quaternion.identity);
                    // add to list
                    fences.Add(tempFence);
                }
                if (j % penSize == 0 && i > 0 && i < penSize - 1)
                {
                    // add to the debt and create a piece
                    manager.GetComponent<DebtMeter>().spendMoney(500);
                    GameObject tempFence = Instantiate(penPieceImg, tempLocation, Quaternion.identity);
                    // add to list
                    fences.Add(tempFence);
                }
            }
        }
    }
}
