using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{   
    // movement speed in units per second
    public float movementSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        // get the input from horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");

        // get the input from vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        // update the position using arrow keys
        //transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime);
        
        // move forwards and backwards using up/down arrows
        transform.position = transform.position + new Vector3(0, 0, verticalInput * movementSpeed * Time.deltaTime);

        // object location
        Vector3 pivotPoint = transform.position;

        // rotate around and around
        // transform.RotateAround(pivotPoint, Vector3.up, 90 * Time.deltaTime);

        // rotate using left and right arrows
        // transform.RotateAround(pivotPoint, Vector3.up, horizontalInput * movementSpeed * Time.deltaTime);

        // rotate freely
        transform.RotateAround(pivotPoint, Vector3.up, movementSpeed * Time.deltaTime);
    }
}
