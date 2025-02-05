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

        float minX = center.x - boxCollider.size.x * 8f;
        float maxX = center.x + boxCollider.size.x * 8f;

        float minY = center.y - boxCollider.size.y * 2f;
        float maxY = center.y + boxCollider.size.y * 2f;

        float minZ = Mathf.Max(center.z - boxCollider.size.z * 2f, -20f);
        float maxZ = Mathf.Min(center.z + boxCollider.size.z * 2f, 20f);

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(minZ, maxZ);

        Vector3 position = new Vector3(x, y, z);
        return position;
    }
}
