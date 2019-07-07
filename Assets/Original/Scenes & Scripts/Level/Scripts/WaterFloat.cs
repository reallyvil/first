using System;
using Viliame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WaterFloat : MonoBehaviour
{
    //properties for the float
    public float AirDrag = 1; //top half of the object dragged by wind
    public float WaterDrag = 10; //object dragged by water
    public bool AffectDirection = true; // direction of where the object will move to
    public bool AttachToSurface = false; // object goes through the surface
    public Transform[] FloatPoints;
    // required components
    protected Rigidbody Rigidbody; //Rigidbody is obviously needed for the object to in the water
    protected Waves Waves; //Waves is needed for the objects location
    protected float WaterLine; // water level
    protected Vector3[] WaterLinePoints; // the location of the water level

    //help Vectors
    protected Vector3 smoothVectorRotation;
    protected Vector3 TargetUp;
    protected Vector3 centerOffset;

    public Vector3 Center { get { return transform.position + centerOffset; } }

    // Start is called before the first frame update
    void Awake()
    {
        //components for the object to float
        Waves = FindObjectOfType<Waves>();
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.useGravity = false; 
        // gravity is obviously ignored since we want the object to float

        //code that makes the floapoint center of the object
        WaterLinePoints = new Vector3[FloatPoints.Length];
        for (int i = 0; i < FloatPoints.Length; i++)
            WaterLinePoints[i] = FloatPoints[i].position;
        centerOffset = PhysicsHelper.GetCenter(WaterLinePoints) - transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //default water surface
        var newWaterLine = 0f;
        var pointUnderWater = false;

        /* this sets the WaterLinePoints and WaterLine 
        because the waves are constantly changing*/
        for (int i = 0; i < FloatPoints.Length; i++)
        {
            //height of the water level
            WaterLinePoints[i] = FloatPoints[i].position;
            WaterLinePoints[i].y = Waves.GetHeight(FloatPoints[i].position);
            newWaterLine += WaterLinePoints[i].y / FloatPoints.Length;
            // if the objects floatpoints are underwater
            if (WaterLinePoints[i].y > FloatPoints[i].position.y)
                pointUnderWater = true;
        }

        var waterLineDelta = newWaterLine - WaterLine;
        WaterLine = newWaterLine;

        //compute up vector
        TargetUp = PhysicsHelper.GetNormal(WaterLinePoints);

        //cubes gravity when on the water
        var gravity = Physics.gravity;
        Rigidbody.drag = AirDrag;
        // if the water level is bigger than the objects center height
        if (WaterLine > Center.y)
        {
            Rigidbody.drag = WaterDrag;
            //and if the top of the object is touching the water surface
            if (AttachToSurface)
            {
                // bring the object downward
                Rigidbody.position = new Vector3(Rigidbody.position.x, WaterLine - centerOffset.y, Rigidbody.position.z);
            }
            else // if the object isn't touching the water surface
            {
                // raise it up because the rigidbody will bring it down
                gravity = AffectDirection ? TargetUp * -Physics.gravity.y : -Physics.gravity;
                transform.Translate(Vector3.up * waterLineDelta * 0.9f);
            }
        }
        Rigidbody.AddForce(gravity * Mathf.Clamp(Mathf.Abs(WaterLine - Center.y),0,1));

        //if the floatpoints are underwater
        if (pointUnderWater)
        {
            //slowly raise it to the water surface
            TargetUp = Vector3.SmoothDamp(transform.up, TargetUp, ref smoothVectorRotation, 0.2f);
            Rigidbody.rotation = Quaternion.FromToRotation(transform.up, TargetUp) * Rigidbody.rotation;
        }
    }

    // this void is just to make a colour the floatpoints
    private void OnDrawGizmos()
    {
        /* line 110 to 131 is when the application hasn't started
        so this basically means you can only see them in green
        when you are in the scene tab*/
        Gizmos.color = Color.green;
        if (FloatPoints == null)
            return;
        // this code is to change the length of the cube 
        for (int i = 0; i < FloatPoints.Length; i++)
        {
            if (FloatPoints[i] == null)
                continue;
            // if the waves are real
            if (Waves != null)
            {

                //this makes cubes colour and szie
                Gizmos.color = Color.red;
                Gizmos.DrawCube(WaterLinePoints[i], Vector3.one * 0.3f);
            }

            //draw sphere
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(FloatPoints[i].position, 0.1f);

        }

        //draw center
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red; // colour of the floapoints so I can see where they are 
            // these two lines are for the size and brightness of the floatpoints
            Gizmos.DrawCube(new Vector3(Center.x, WaterLine, Center.z), Vector3.one * 1f);
            Gizmos.DrawRay(new Vector3(Center.x, WaterLine, Center.z), TargetUp * 1f);
        }
    }
}