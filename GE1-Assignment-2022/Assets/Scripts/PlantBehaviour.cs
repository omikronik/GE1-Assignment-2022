using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public int maxWaterLevel = 5;
    public int startWaterLevel = 0;

    public int waterLevel;

    public void AddWaterLevel()
    {
        waterLevel += 1;
        Debug.Log($"New Water Level: {GetWaterLevel()}");
    }

    public int GetWaterLevel()
    {
        return waterLevel;
    }

    void Start()
    {
        waterLevel = startWaterLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
