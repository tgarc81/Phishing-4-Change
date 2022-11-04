using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetSquaredDistanceBetween(GameObject entity)
    {
        // Entity one center, x coord
        float entity1CenterX = gameObject.GetComponent<CapsuleCollider>().bounds.center.x;
        // Vehicle center, y coord
        float entity1CenterZ = gameObject.GetComponent<CapsuleCollider>().bounds.center.z;
        // Entity center, x coord
        float entity2CenterX = entity.GetComponent<CapsuleCollider>().bounds.center.x;
        // Entity center, y coord
        float entity2CenterZ = entity.GetComponent<CapsuleCollider>().bounds.center.z;

        // Distance between vehicle and entity's center squared
        float distanceSquared = Mathf.Pow((entity1CenterX - entity2CenterX), 2) + Mathf.Pow((entity1CenterZ - entity2CenterZ), 2);

        // Distance between vehicle and entity
        return distanceSquared;
    }

    
}
