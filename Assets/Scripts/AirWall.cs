using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWall : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "viking")
        {
            Debug.Log("viking just hit the wall");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "viking")
        {
            Debug.Log("viking is hitting the wall");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "viking")
        {
            Debug.Log("viking just left the wall");
        }

    }
}
