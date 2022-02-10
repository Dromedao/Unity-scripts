using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement3D : MonoBehaviour
{
    Rigidbody rb;
    public float velocity;
    public float sensibility;
    public new Camera camera;
    private float limiteRotacion;
    private float verticalMovement;
    private float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the movement of the mouse
        horizontalMovement = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        verticalMovement = Input.GetAxis("Mouse Y") * -sensibility * Time.deltaTime;

        // Sets horizontal limits to mouse movement
        transform.Rotate(0, horizontalMovement, 0);
        limiteRotacion += verticalMovement;
        limiteRotacion = Mathf.Clamp(limiteRotacion, -60f, 90f);
        camera.transform.localEulerAngles = new Vector3(limiteRotacion, 0, 0);

        // Running method
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocity *= 1.5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocity /= 1.5f;
        }

        // Get the keys to move the character
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddRelativeForce(0, 0, velocity/2, ForceMode.Impulse);
                rb.AddRelativeForce(-velocity/2, 0, 0, ForceMode.Impulse);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.AddRelativeForce(0, 0, velocity/2, ForceMode.Impulse);
                rb.AddRelativeForce(velocity/2, 0, 0, ForceMode.Impulse);
            }
            else
            {
                rb.AddRelativeForce(0, 0, velocity, ForceMode.Impulse);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddRelativeForce(0, 0, -velocity/2, ForceMode.Impulse);
                rb.AddRelativeForce(-velocity/2, 0, 0, ForceMode.Impulse);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.AddRelativeForce(0, 0, -velocity/2, ForceMode.Impulse);
                rb.AddRelativeForce(velocity/2, 0, 0, ForceMode.Impulse);
            }
            else
            {
                rb.AddRelativeForce(0, 0, -velocity, ForceMode.Impulse);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeForce(-velocity/2, 0, 0, ForceMode.Impulse);
                rb.AddRelativeForce(0, 0, velocity/2, ForceMode.Impulse);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.AddRelativeForce(-velocity/2, 0, 0, ForceMode.Impulse);
                rb.AddRelativeForce(0, 0, -velocity/2, ForceMode.Impulse);
            }
            else
            {
                rb.AddRelativeForce(-velocity, 0, 0, ForceMode.Impulse);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeForce(velocity/2, 0, 0, ForceMode.Impulse);
                rb.AddRelativeForce(0, 0, velocity/2, ForceMode.Impulse);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.AddRelativeForce(velocity/2, 0, 0, ForceMode.Impulse);
                rb.AddRelativeForce(0, 0, -velocity/2, ForceMode.Impulse);
            }
            else
            {
                rb.AddRelativeForce(velocity, 0, 0, ForceMode.Impulse);
            }
        }
    }
}
