using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{

    public float movementSpeed = 2;

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
}
