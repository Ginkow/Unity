using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        if (Timer.IsGameEnd)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Target target = hit.transform.GetComponent<Target>(); 
                if (target != null)
                {
                    target.Shooter();
                    Score.Instance.AddScore(100);
                    Accuracy.Instance.Hit();
                } else {
                    Accuracy.Instance.Miss();
                }
            } else {
                Accuracy.Instance.Miss();
            }
        }
    }
}
