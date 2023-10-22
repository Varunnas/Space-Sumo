using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    public GameObject[]  powerUp;
    private int enemyCount;
    private int waveNumber = 1;
    void Start()
    {
        int powerUpelement = Random.Range(0, powerUp.Length);
        SpawnEnemy(waveNumber);
        Instantiate(powerUp[powerUpelement], RandomPos(), powerUp[powerUpelement].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
            int powerUpelement = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[powerUpelement], RandomPos(), powerUp[powerUpelement].transform.rotation);  
        }
        

    }

    void SpawnEnemy(int enemyToSpawn)
    {
        for(int i = 0; i < enemyToSpawn; i++)
        {
            int enemyPrefabElement = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyPrefabElement], RandomPos(), enemyPrefabs[enemyPrefabElement].transform.rotation);
        }
        
    }
     
    private Vector3 RandomPos()
    {
         float randomX = Random.Range(-7.0f, 7.3f);
         float randomZ = Random.Range(-12.0f, 11f);
         Vector3 randomPos = new Vector3(randomX , 0 , randomZ);
         return randomPos;
    }
}
