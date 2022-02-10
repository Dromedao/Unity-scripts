using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private float velocidad = 1f;
    private float angle;
    public Vector3 direction;
    private AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;
    public bool canOpen;
    public bool open;
    public Collider door;

    // Start is called before the first frame update
    void Start()
    {
        angle = transform.eulerAngles.y;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen == true)
        {
            if (door.gameObject.transform.localEulerAngles.y >= 85)

            {
                angle = 0;
                direction = Vector3.down;
                open = true;
                audioSource.PlayOneShot(closeSound);

            }
            else if (door.gameObject.transform.localEulerAngles.y >= 0)
            {
                angle = 85;
                direction = Vector3.up;
                open = true;
                audioSource.PlayOneShot(openSound);
            }
        }
        if (open == true)
        {
            if (Mathf.Round(door.gameObject.transform.localEulerAngles.y) != angle)
            {
                door.gameObject.transform.Rotate(direction * velocidad);
            }
            else if (Mathf.Round(door.gameObject.transform.localEulerAngles.y) == angle)
            {
                open = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Puerta"))
        {
            canOpen = true;
            door = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Puerta"))
        {
            canOpen = false;
        }
    }
}