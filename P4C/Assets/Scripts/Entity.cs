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
        // Vehicle center, x coord
        float playerCenterX = gameObject.GetComponent<CapsuleCollider>().bounds.center.x;
        // Vehicle center, y coord
        float playerCenterZ = gameObject.GetComponent<CapsuleCollider>().bounds.center.z;
        // Entity center, x coord
        float entityCenterX = entity.GetComponent<CapsuleCollider>().bounds.center.x;
        // Entity center, y coord
        float entityCenterZ = entity.GetComponent<CapsuleCollider>().bounds.center.z;

        // Distance between vehicle and entity's center squared
        float distanceSquared = Mathf.Pow((playerCenterX - entityCenterX), 2) + Mathf.Pow((playerCenterZ - entityCenterZ), 2);

        // Distance between vehicle and entity
        return distanceSquared;
    }

    
}
