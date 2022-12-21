using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject doggo;
    public GameObject plantPrefab;
    public List<GameObject> plants;
    public int playerScore = 0;

    public int maxNumPlants = 10;
    public float spawnRadius = 15.0f;
    public float minDistance = 1.0f;
    IEnumerable CheckWaterLevels()
    {
        while (true)
        {
        
        }
    }

    IEnumerator SpawnPlants()
    {
        Debug.Log("Hello from spawnPlants");
        while (plants.Count < maxNumPlants) {
            Vector3 randomPos = Random.insideUnitSphere * spawnRadius;

            bool isTooClose = false;
            foreach (GameObject plant in plants)
            {
                // Account for doggo pos and distance from other pots
                if (Vector3.Distance(randomPos, plant.transform.position) < minDistance
                    && Vector3.Distance(randomPos, doggo.transform.position) < minDistance)
                {
                    isTooClose = true;
                    break;
                }
            }

            if (!isTooClose)
            {
                GameObject plant = Instantiate(plantPrefab, transform.position + new Vector3(randomPos.x, -0.5f, randomPos.z), Quaternion.Euler(-90.0f, 0, 0));
                plants.Add(plant);
            }


            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator CheckHealthValues()
    {
        while (true)
        {
            if (plants.Count != 0)
            {
                foreach (GameObject plant in plants)
                {
                    PlantBehaviour plantBehaviour = plant.GetComponent<PlantBehaviour>();

                    if (plantBehaviour.GetWaterLevel() >= plantBehaviour.maxWaterLevel)
                    {
                        Destroy(plant);
                        playerScore += 1;
                        break;
                    }
                }

            }


            yield return new WaitForSeconds(0.5f);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnPlants());
        StartCoroutine(CheckHealthValues());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
