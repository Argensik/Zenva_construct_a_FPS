using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;                 //movement speed in units per second
    public float jumpForce;                 //force applied upwards

    [Header("Camera")]
    public float lookSensitivity;           //mouse look sensitivity
    public float maxLookX;                  //lowest we can look down
    public float miLookY;                   //highest we can look up
    private float rotX;                     //current x rotation of the camera


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
