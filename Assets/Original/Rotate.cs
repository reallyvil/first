using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // void for rotating the collectable items
    void rotate()
    {
        //simply rotates the object by X,Y,Z
        transform.Rotate(new Vector3 (15,30,45)  * Time.deltaTime);
    }
}
