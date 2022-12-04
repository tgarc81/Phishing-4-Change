using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public float movementSpeed = 4;
    public Vector3 locationSaver;
    [SerializeField] GameObject popUpText;
    [SerializeField] GameObject storeHUD;
    [SerializeField] GameObject gameHUD;

    // trap variables
    [SerializeField] public GameObject trap;
    public GameObject trapSpot;
    bool trapTrigger;

    // rod variables
    [SerializeField] public GameObject rod;
    public GameObject rodSpot;
    bool rodTrigger;

    // boat variables
    [SerializeField] public GameObject boat;
    public GameObject boatSpot;
    bool boatTrigger;


    // Start is called before the first frame update
    void Start()
    {
        //popUpText = GameObject.Find("Interaction Pop-Up");
    }

    // Update is called once per frame
    void Update()
    {
        // Movement -------------------------------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 2.0f;
        } 

        else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 2.0f;
        }

        else if (Input.GetKey("s"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 2.0f;
        }

        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.0f;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.0f;
        }
        //----------------------------------------------------------------------------------------------------------------

        // Placement Controls-----------------------------------------------------
        if (trapTrigger && Input.GetKeyDown(KeyCode.T))
        {
            trapSpot.SetActive(false);
            PlaceTrap(locationSaver);
            trapTrigger = false;
            popUpText.gameObject.SetActive(false);
        }

        if (rodTrigger && Input.GetKeyDown(KeyCode.R))
        {
            rodSpot.SetActive(false);
            PlaceRod(locationSaver, new Quaternion(0, 180, 0, 1));
            rodTrigger = false;
            popUpText.gameObject.SetActive(false);
        }

        if (boatTrigger && Input.GetKeyDown(KeyCode.B))
        {
            boatSpot.SetActive(false);
            PlaceBoat(locationSaver);
            boatTrigger = false;
            popUpText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other.gameObject.tag);

        if (other.CompareTag("TrapLocation") && other.gameObject.activeInHierarchy == true)
        {
            trapSpot = other.gameObject;
            locationSaver = other.gameObject.transform.position;
            trapTrigger = true;
            popUpText.gameObject.SetActive(true);
            popUpText.gameObject.GetComponent<Text>().text = "Press T to place Trap";
        }

        if (other.CompareTag("RodLocation") && other.gameObject.activeInHierarchy == true)
        {
            rodSpot = other.gameObject;
            locationSaver = other.gameObject.transform.position;
            rodTrigger = true;
            popUpText.gameObject.SetActive(true);
            popUpText.gameObject.GetComponent<Text>().text = "Press R to place Fishing Rod";
        }

        if (other.CompareTag("BoatLocation") && other.gameObject.activeInHierarchy == true)
        {
            boatSpot = other.gameObject;
            locationSaver = other.gameObject.transform.position;
            boatTrigger = true;
            popUpText.gameObject.SetActive(true);
            popUpText.gameObject.GetComponent<Text>().text = "Press B to send out fishing boat";
        }

        if (other.gameObject.name == "House")
        {
            Debug.Log("We Have collided w the house boys...");
            // MAKE THE UI FOR SHOPS POP UP
            storeHUD.gameObject.SetActive(true);
            gameHUD.gameObject.SetActive(false);
        }
    }
        void OnTriggerExit(Collider other)
        {
            popUpText.gameObject.SetActive(false);
            trapTrigger = false;
            rodTrigger = false;
        }

        void PlaceTrap(Vector3 location)
        {
            //Debug.Log("Try Instantiate");
            gameManager.PlaceBasketTrap();
            Instantiate(trap, location, Quaternion.identity);
            for (int i = 0; i < gameManager.fishingTraps.Length; i++)
            {
                if (gameManager.fishingTraps[i] != null)
                {
                    gameManager.fishingTraps[i] = trap;
                }
            }
        }

        void PlaceRod(Vector3 location, Quaternion rotation)
        {
            //Debug.Log("Try Instantiate");
            gameManager.PlaceRod();
            Instantiate(rod, location, rotation);
            for (int i = 0; i < gameManager.fishingRods.Length; i++)
            {
                if (gameManager.fishingRods[i] != null)
                {
                    gameManager.fishingRods[i] = rod;
                }
            }
        }

        void PlaceBoat(Vector3 location)
        {
            //Debug.Log("Try Instantiate");
            gameManager.PlaceBoat();
            //Instantiate(boat, new Vector3(location.x + 0.5f, location.y - .2f, location.z), Quaternion.identity);
            //for (int i = 0; i < gameManager.fishingBoats.Length; i++)
            //{
            //    if (gameManager.fishingBoats[i] != null)
            //    {
            //        gameManager.fishingBoats[i] = boat;
            //    }
            //}
        }

    public void CloseStore()
    {
        storeHUD.gameObject.SetActive(false);
        gameHUD.gameObject.SetActive(true);
    }
}

