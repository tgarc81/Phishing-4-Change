using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Represents all the buttons on the scene
    public List<Entity> buttons;

    // Represents the player
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interaction();
    }

    private void Interaction()
    {
        foreach (Entity button in buttons)
        {
            float distBetween = Mathf.Sqrt(button.GetSquaredDistanceBetween(player));
            if (distBetween < 5) // Every Unity unit is exactly 10 Cartesian units. Therefore 5 Unity units away is 50 Cartesian units away
            {
                Debug.Log("Interaction detected between player and button: " + button.name);
            }
        }
    }

}
