using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject plantPrefab;
    public List<GameObject> plants;
    public int playerScore = 0;

    public int maxNumPlants = 10;
    public float spawnRadius = 5;
    public float minDistance = 1.5f;
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
            Vector3 randomPos;
            bool validPos = false;
            while (validPos == false)
            {
                randomPos = Random.insideUnitSphere * spawnRadius;

                foreach (GameObject plant in plants)
                {
                    if (Vector3.Distance(randomPos, plant.transform.position) < minDistance)
                    {
                        validPos = false;
                        break;
                    }
                    else
                    {
                        Instantiate(plantPrefab, transform.position + randomPos, Quaternion.identity);
                        validPos = true;
                        break;
                    }
                }
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
