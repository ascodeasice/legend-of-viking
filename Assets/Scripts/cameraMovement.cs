using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField]float horizontalSpeed=0.2f;
    [SerializeField]float verticalSpeed= 0.2f;

    float yaw = 0f;
    float pitch = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw+=horizontalSpeed*Input.GetAxis("Mouse X");
        pitch-=verticalSpeed*Input.GetAxis("Mouse Y");

        // add limit of camera angle
        pitch = Mathf.Clamp(pitch, -60f, 60f);

        transform.eulerAngles = new Vector3(pitch,yaw,0.0f) ;
    }
}
