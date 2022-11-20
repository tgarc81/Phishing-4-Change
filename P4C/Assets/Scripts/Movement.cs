using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public float movementSpeed = 2;
    public Vector3 locationSaver;
    [SerializeField] public GameObject trap;
    [SerializeField] public GameObject rod;
    public GameObject trapSpot;
    bool trapTrigger;
    public GameObject rodSpot;
    bool rodTrigger;
    [SerializeField] GameObject popUpText;

    // Start is called before the first frame update
    void Start()
    {
        //popUpText = GameObject.Find("Interaction Pop-Up");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey("w")) 
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 1.8f;
        } 

        else if (Input.GetKey("w") && !Input.GetKey (KeyCode.LeftShift))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 1.8f;
        }

        else if (Input.GetKey ("s"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 1.8f;
        }

        if(Input.GetKey("a") && !Input.GetKey ("d")) 
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 1.8f;
        }
        else if (Input.GetKey ("d") && !Input.GetKey ("a"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 1.8f;
        }


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
            PlaceRod(locationSaver, new Quaternion(0,180,0,1));
            rodTrigger = false;
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
    }

    private void OnTriggerExit(Collider other)
    {
        popUpText.gameObject.SetActive(false);
        trapTrigger = false;
        rodTrigger = false;
    }

    public void PlaceTrap(Vector3 location)
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

    public void PlaceRod(Vector3 location, Quaternion rotation)
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
}
