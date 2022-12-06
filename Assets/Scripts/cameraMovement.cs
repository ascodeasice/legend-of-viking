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
        pitch-=horizontalSpeed*Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch,yaw,0.0f);
    }
}
