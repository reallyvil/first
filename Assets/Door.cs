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
    void OpenTheDoor(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true;
        }
    }

    void closeTheDoor(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }

    void Update()
    {
        if (open == true)
        {
            var target = Quaternion.Euler (0, OpenDoor, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * Speed);
        }
        if (open == false)
        {
            var target1 = Quaternion.Euler (0, CloseDoor, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * Speed);
        }
        if (enter == true) //If i touch the door
        {
            if(Input.GetKeyDown("e"))
            {
                open = !open;
            }
        }
    }
}
