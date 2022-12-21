using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantBehaviour : MonoBehaviour
{
    public int maxWaterLevel = 5;
    public int startWaterLevel = 0;

    public int waterLevel;
    public Slider waterLevelSlider;

    public void AddWaterLevel()
    {
        waterLevel += 1;
        if (waterLevelSlider != null)
        {
            waterLevelSlider.value = waterLevel;
        }
    }

    public int GetWaterLevel()
    {
        return waterLevel;
    }

    void Start()
    {
        waterLevel = startWaterLevel;

        GameObject childGO = transform.Find("Canvas").gameObject;
        GameObject grandchildGO = childGO.transform.Find("WaterLevelSlider").gameObject;

        waterLevelSlider = transform.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
