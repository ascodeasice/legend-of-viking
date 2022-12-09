using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotation : MonoBehaviour
{
    [SerializeField] Vector3 rotationDirection;
    [SerializeField]float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationDirection*rotationSpeed*Time.deltaTime);
    }
}
