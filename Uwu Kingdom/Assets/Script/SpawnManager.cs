using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
   
    private int enemyIndex;
    private float spawnRangeX = 8f;
    private float spawnPosZ=45;

    [SerializeField, Range(2, 5)]
    private float startDelay = 2f;
    
    [SerializeField, Range(0.1f, 3f)]
    private float spawnInterval = 1.0f;
    private void Start()
    {
          spawnPosZ = this.transform.position.z;
                InvokeRepeating("SpawnRandomEnemy",
                    startDelay,spawnInterval);
    }
    
    private void SpawnRandomEnemy()
    {
        //Generar la posición donde va a aparecer el próximo enemigo
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand,2, spawnPosZ);

        enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex],
            spawnPos,
            enemies[enemyIndex].transform.rotation);

    }
    
    
    
    
}
