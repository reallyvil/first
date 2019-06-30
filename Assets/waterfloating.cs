using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfloating : MonoBehaviour
{
    //properties
    public float airDrag = 1;
    public float waterDrag = 10;
    public Transform[] FloatPoints;
    protected Rigidbody Rigidbody;
    protected waves Waves;
    protected float waterLine;
    protected Vector3[] waterLinePoints;
    protected Vector3 centerOffset;
    public Vector3 Center { get {return Transform.position + centerOffset;}}

    // Start is called before the first frame update
    void Start()
    {
       Waves = findObjectOfType<water>();
       Rigidbody = getComponent<Rigidbody>();
       Rigidbody.useGravity = false; // makes the rigibody float 

       waterLinePoints = new Vector3[FloatPoints.Length];
       for (int a = 0; a < FloatPoints.Length; a++)
       waterLinePoints[a] = FloatPoints[a].position;
       centerOffset = PhysicsSupport.getCenter(waterLinePoints) - Transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
