using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float speed = 50.0f;
    // void for rotating the collectable items
    void Update()
    {
        //simply rotates the object by X,Y,Z
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
