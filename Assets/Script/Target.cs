using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Shooter(){
        transform.position = Zone.Instance.targetPosition();
    }
}
