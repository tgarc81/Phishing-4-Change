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
        fishPop = 500;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceBasketTrap();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dayEnd = true;
        }

        if (dayEnd == true)
        {
            dayNumber++;
            FishPopulationChange();
            dayEnd = false;
            caughtFish = 0;
            return;
        }
    }

    public void FishPopulationChange()
    {
        fishPop -= caughtFish;

        if (fishPop >= 1000)
        {
            fishPop = (fishPop / 2) - 50;
        }

        // Balanced Population Change
        if (fishPop >= 350)
        {
            fishPop += 20;
        }
        // Negative Population Change
        else if (fishPop < 350 && fishPop >= 200)
        {
            fishPop += 10;
        }
        else if (fishPop < 200)
        {
            fishPop -= 50;
        }

        if (fishPop <= 0)
        {
            Debug.Log("FISH POPULATION DECIMATED! GAME OVER!");
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    public void PlaceBasketTrap()
    {
        caughtFish += 5;
    }

    public void PlaceRod()
    {
        caughtFish += 10;
    }

    public void NetFishing()
    {
        caughtFish += 40;
    }
}
