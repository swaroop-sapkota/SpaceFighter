using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public int xPos1, xPos2, xPos3, xPos4, xPos5;
    public int zPos1, zPos2, zPos3, zPos4, zPos5;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());

    }

    private IEnumerator SpawnEnemies()
    {
        while(EnemyCount < 4)
        {
            xPos1 = Random.Range(-10, 37);
            zPos1 = Random.Range(10, 90);
            
            xPos1 = Random.Range(0, -45);
            zPos1 = Random.Range(13, -55);
            
            xPos1 = Random.Range(0, -50);
            zPos1 = Random.Range(40, 90);
            
            xPos1 = Random.Range(-90, -30);
            zPos1 = Random.Range(30, 60);
            
            xPos1 = Random.Range(-25, -53);
            zPos1 = Random.Range(0, 30);



            Instantiate(Enemy1, new Vector3(xPos1, 4, zPos1), Quaternion.identity);
            Instantiate(Enemy2, new Vector3(xPos2, 4, zPos2), Quaternion.identity);
            Instantiate(Enemy3, new Vector3(xPos3, 4, zPos3), Quaternion.identity);
            Instantiate(Enemy4, new Vector3(xPos4, 4, zPos4), Quaternion.identity);
            Instantiate(Enemy5, new Vector3(xPos5, 4, zPos5), Quaternion.identity);
            yield return new WaitForSeconds(5);
            EnemyCount += 1;
        }
    }
}

