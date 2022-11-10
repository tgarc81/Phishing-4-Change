using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public float movementSpeed = 2;
    //public Vector3 locationSaver;
    [SerializeField] public GameObject trap;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey("w")) {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        } 
        else if (Input.GetKey("w") && !Input.GetKey (KeyCode.LeftShift))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey ("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if(Input.GetKey("a") && !Input.GetKey ("d")) {
            transform.position += transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey ("d") && !Input.GetKey ("a")) {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime* movementSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other.gameObject.tag);
        PlaceTrap(other.transform.position);

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.tag);
    //    PlaceTrap(collision.transform.position);
    //}

    public void PlaceTrap(Vector3 location)
    {
        Debug.Log("Try Instantiate");
        gameManager.PlaceBasketTrap();
        Instantiate(trap, location, Quaternion.identity);
        
    }
}
