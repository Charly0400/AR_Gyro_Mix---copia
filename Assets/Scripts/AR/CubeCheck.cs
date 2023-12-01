using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCheck : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
     if(Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (finger.phase == TouchPhase.Began)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }

            if (finger.phase == TouchPhase.Ended)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
        }   
    }
}
