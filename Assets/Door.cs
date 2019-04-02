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
    //
    void Button()
    {
        if (Input.GetKeyDown("e")) // and if the player pressed "e"
        {
            var target = Quaternion.Euler(0, OpenDoor, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * Speed);
        }
        else
        {
            var target1 = Quaternion.Euler(0, CloseDoor, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * Speed);
        }
    }

    /*void Open()
    {
        if ((Input.GetKeyDown("e")) == true) // If the player did press e
        {
            var target = Quaternion.Euler (0, OpenDoor, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * Speed);
        }
        else
        {
            var target1 = Quaternion.Euler (0, CloseDoor, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * Speed);
        }
    }*/
}
