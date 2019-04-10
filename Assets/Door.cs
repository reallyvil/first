using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool open;
    bool enter;
    float OpenDoor = 90.0f; // Door's new position when it opens
    float CloseDoor = 0.0f; // Door's original position before it opened
    float Speed = 2.0f; // Speed of the door when closing/opening
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player") // If the player collides with the door
        {
            var target = Quaternion.Euler(0, OpenDoor, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * Speed);
        }
        if (other.gameObject.name == "Player")
        {
            var target1 = Quaternion.Euler(0, CloseDoor, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * Speed);
        }
    }
}
