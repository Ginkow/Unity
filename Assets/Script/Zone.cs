using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public static Zone Instance;

    void Awake()
    {
        Instance = this;
    }
    public BoxCollider boxCollider;
    
    public Vector3 targetPosition(){
        Vector3 center = boxCollider.center + transform.position;

        float minX = center.x - boxCollider.size.x * 2f;
        float maxX = center.x + boxCollider.size.x * 2f;

        float minY = center.x - boxCollider.size.x * 2f;
        float maxY = center.x + boxCollider.size.x * 2f;

        float minZ = center.x - boxCollider.size.x * 2f;
        float maxZ = center.x + boxCollider.size.x * 2f;

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(minZ, maxZ);

        Vector3 position = new Vector3(x, y, z);
        return position;
    }
}
