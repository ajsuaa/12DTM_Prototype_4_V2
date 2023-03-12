using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //make gameobject real
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    //see how much enemies there are
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        //the number tells how many balls should spawn
        SpawnEnemyWave(3); 
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        
        //makes specific number of balls 
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //spawn random balls  
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //enemy
        enemyCountCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        { 
            SpawnEnemyWave(1);
        }
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

