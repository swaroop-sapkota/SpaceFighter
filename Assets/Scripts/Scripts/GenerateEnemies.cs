using System.Collections;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos;
    public int zPos;

    public int enemyCount;
   
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(64, 80);
            zPos = Random.Range(-41, -6);
            Instantiate(theEnemy, new Vector3(xPos, (Random.Range(4,10)), zPos), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            enemyCount++;
        }
    }

  
}
