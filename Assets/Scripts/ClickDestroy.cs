using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // 2D to 3D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // a struct to get info back from ray
            RaycastHit raycastHit;
            
            // raycasting
            if(Physics.Raycast(ray, out raycastHit))
            {
                Debug.Log(raycastHit.transform.name);
                if (raycastHit.transform.gameObject.CompareTag("collectable"))
                {
                    Destroy(raycastHit.transform.gameObject);
                }
            }

        }
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
