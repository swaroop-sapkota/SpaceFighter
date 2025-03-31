using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());

    }

    private IEnumerator SpawnEnemies()
    {
        while(EnemyCount < 20)
        {
            xPos = Random.Range(1, 50);
            zPos = Random.Range(0, 20);
            Instantiate(theEnemy, new Vector3(xPos, 4, zPos), Quaternion.identity);
            yield return new WaitForSeconds(10);
            EnemyCount += 1;
        }
    }
}

