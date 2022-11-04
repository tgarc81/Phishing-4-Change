using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text fishPopTB;
    public Text dayCounter;
    public int fishPop;
    public int dayNumber;
    public int caughtFish;
    public bool dayEnd;

    // Start is called before the first frame update
    void Start()
    {
        //fishPopTB = GetComponent<Text>();
        fishPop = 100;
        dayNumber = 1;
        caughtFish = 0;
        dayEnd = false;
        //fishPopTB.GetComponent<Text>().text = "Fish Population: " + fishPop.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Recording the UI Elements
        fishPopTB.GetComponent<Text>().text = "Fish Population: " + fishPop.ToString();
        dayCounter.GetComponent<Text>().text = "Day: " + dayNumber.ToString();


        if (dayEnd == true)
        {
            dayNumber++;
            FishPopulationChange();
            dayEnd = false;
            return;
        }
    }

    public void FishPopulationChange()
    {
        fishPop -= caughtFish;
        // Balanced Population Change
        if (fishPop >= 75)
        {
            fishPop += 15;
        }
        // Negative Population Change
        if (fishPop >= 150)
        {
            fishPop -= fishPop / 2;
        }
        else
        {
            fishPop += 7;
        }
    }
}
