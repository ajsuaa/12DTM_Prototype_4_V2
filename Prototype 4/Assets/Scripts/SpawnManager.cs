using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //make gameobject real
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        //spawn random balls 
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //making custom functions = more neat
    private Vector3 GenerateSpawnPosition()
    {
        //spawn balls in random positions
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

}

