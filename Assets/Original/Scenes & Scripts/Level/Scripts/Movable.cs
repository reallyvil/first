using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    // properties
    float playerForce = 800; // force of the user
    Vector3 objectPos;
    float distance;
    public bool canHold = true;
    public GameObject item;
    public GameObject temParent;
    public bool isHolding = false;

    // 
    void TheForce()
    {
        distance = Vector3.Distance(item.transform.position, temParent .transform.position);
        if (distance >= 1f)
        {
            isHolding = false;
        }
        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(temParent.transform);

            if (Input.GetMouseButtonDown(0))
            {
                item.GetComponent<Rigidbody>().AddForce(temParent.transform.forward * playerForce);
                isHolding = false;
            }
        } 
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }
    private void OnMouseDown()
    {
        if (distance <= 1f)

        isHolding= true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
    }
    void OnMouseUp()
    {
        isHolding = false;
    }
}
