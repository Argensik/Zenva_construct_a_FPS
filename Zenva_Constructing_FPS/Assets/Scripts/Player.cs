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
    public float minLookX;                   //highest we can look up
    float rotX;                     //current x rotation of the camera

    Camera cam;
    Rigidbody rig;

    private void Awake()
    {
        //get the components
        cam = Camera.main;
        rig = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
            JumpFunction();

        CamLook();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);

        transform.eulerAngles += Vector3.up * y;
    }

    void JumpFunction()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, 1.1f))
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
