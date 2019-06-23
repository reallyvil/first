using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterFilter : MonoBehaviour
{
    public float WaterLevel;
    private bool inTheWater;
    private Color outOfTheWater;
    private Color insideWater;

    // Start is called before the first frame update
    void Start()
    {
        outOfTheWater = new Color (0.5f, 0.5f, 0.5f, 0.5f);
        insideWater = new Color (0.22f, 0.65f, 0.77f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        /* if the water level is greater than the users 
        vertical position */
        if ((transform.position.y < WaterLevel) != inTheWater)
        {
            inTheWater = transform.position.y < WaterLevel;
            if (inTheWater) 
            {
                waterFilter();
            }
            
            if (!inTheWater) 
            {
                normal();
            }
        }
    }
    void waterFilter()
    {
        RenderSettings.fogColor = insideWater;
        RenderSettings.fogDensity = 0.03f;
    }
    void normal()
    {
        RenderSettings.fogColor = outOfTheWater;
        RenderSettings.fogDensity = 0.03f;
    }
}
