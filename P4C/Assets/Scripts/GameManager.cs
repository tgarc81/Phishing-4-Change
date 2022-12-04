using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
   [SerializeField]public  Text fishPopTB;
   [SerializeField]public  Text dayCounter;
   [SerializeField] public Text moneyCount;
   [SerializeField] public Text moneyCountForStore;
    public int fishPop;
    public int dayNumber = 1;
    public int caughtFish;
    public bool dayEnd = false;

    public int money; // the amount of money the player has

    public GameObject[] trapLocations;
    public GameObject[] rodLocations;
    public GameObject[] boatLocations;
    public GameObject[] fishingTraps;
    public GameObject[] fishingRods;
    public GameObject[] fishingBoats;

    // Start is called before the first frame update
    void Start()
    {
        fishPop = 500;
        dayNumber = 1;
        money = 0;
        //caughtFish = 0;
        dayEnd = false;

        trapLocations = GameObject.FindGameObjectsWithTag("TrapLocation");
        rodLocations = GameObject.FindGameObjectsWithTag("RodLocation");
        boatLocations = GameObject.FindGameObjectsWithTag("BoatLocation");
    }

    // Update is called once per frame
    void Update()
    {
        // Recording the UI Elements
        fishPopTB.GetComponent<Text>().text = "Fish Population: " + fishPop.ToString();
        dayCounter.GetComponent<Text>().text = "Day: " + dayNumber.ToString();
        moneyCount.GetComponent<Text>().text = "Money: " + money.ToString();
        moneyCountForStore.GetComponent<Text>().text = "Money: " + money.ToString();

        // Keybind for ending day
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

            fishingTraps = GameObject.FindGameObjectsWithTag("Trap");
            fishingRods = GameObject.FindGameObjectsWithTag("Rod");
            foreach (GameObject t in fishingTraps)
            {
                Destroy(t);
            }
            
            foreach (GameObject r in fishingRods)
            {
                Destroy(r);
            }


            foreach (GameObject t in trapLocations)
            {
                t.gameObject.SetActive(true);
            }

            foreach (GameObject r in rodLocations)
            {
                r.gameObject.SetActive(true);
            }

            foreach (GameObject b in boatLocations)
            {
                b.gameObject.SetActive(true);
            }

            return;
        }
    }

    /// <summary>
    /// Handles fish population changes based on population after day change
    /// </summary>
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
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    public void PlaceBasketTrap()
    {
        //fishPop -= Random.Range(0, 5);
        int randNum = Random.Range(0, 5);
        caughtFish += randNum;
        money += randNum;
    }

    public void PlaceRod()
    {
        //fishPop -= Random.Range(5,10);
        int randNum = Random.Range(5, 10);
        caughtFish += randNum;
        money += randNum;
    }

    public void PlaceBoat()
    {
        int randNum = Random.Range(10, 40);
        fishPop -= randNum;
        money += caughtFish;
    }
}
