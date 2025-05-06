using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public GameObject Enemy7;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 4)
        {
            // Generate random positions for each enemy
            float xPos1 = Random.Range(-80, -40);
            float zPos1 = Random.Range(30, 50);

            float xPos2 = Random.Range(60, 85);
            float zPos2 = Random.Range(-15, -50);

            float xPos3 = Random.Range(-50, 0);
            float zPos3 = Random.Range(40, 90);

            float xPos4 = Random.Range(-90, -30);
            float zPos4 = Random.Range(30, 60);

            float xPos5 = Random.Range(0, 50);
            float zPos5 = Random.Range(-70, -110);
            
            float xPos6 = Random.Range(-20, 20);
            float zPos6 = Random.Range(60, 90);
            
            float xPos7 = Random.Range(0, -30);
            float zPos7 = Random.Range(-10, 20);

            // Sample valid NavMesh positions
            Vector3 pos1 = GetNavMeshPosition(new Vector3(xPos1, 20f, zPos1));
            Vector3 pos2 = GetNavMeshPosition(new Vector3(xPos2, 20f, zPos2));
            Vector3 pos3 = GetNavMeshPosition(new Vector3(xPos3, 20f, zPos3));
            Vector3 pos4 = GetNavMeshPosition(new Vector3(xPos4, 20f, zPos4));
            Vector3 pos5 = GetNavMeshPosition(new Vector3(xPos5, 20f, zPos5));
            Vector3 pos6 = GetNavMeshPosition(new Vector3(xPos6, 20f, zPos6));
            Vector3 pos7 = GetNavMeshPosition(new Vector3(xPos7, 20f, zPos7));

            // Instantiate enemies at these sampled NavMesh positions
            Instantiate(Enemy1, pos1, Quaternion.identity);
            Instantiate(Enemy2, pos2, Quaternion.identity);
            Instantiate(Enemy3, pos3, Quaternion.identity);
            Instantiate(Enemy4, pos4, Quaternion.identity);
            Instantiate(Enemy5, pos5, Quaternion.identity);
            Instantiate(Enemy6, pos6, Quaternion.identity);

            yield return new WaitForSeconds(5);
            EnemyCount += 1;
        }
    }

    private Vector3 GetNavMeshPosition(Vector3 sourcePosition)
    {
        NavMeshHit navHit;

        // Increase sample radius to make sure we find walkable ground in varied terrain
        if (NavMesh.SamplePosition(sourcePosition, out navHit, 20.0f, NavMesh.AllAreas))
        {
            // Now raycast from above that nav mesh point to get the real surface
            Vector3 rayOrigin = navHit.position + Vector3.up * 10f;
            Ray ray = new Ray(rayOrigin, Vector3.down);
            RaycastHit surfaceHit;

            if (Physics.Raycast(ray, out surfaceHit, 20f))
            {
                return surfaceHit.point + Vector3.up * 0.5f; // Slightly above ground
            }

            // If raycast fails, still use the NavMesh position
            return navHit.position + Vector3.up * 0.5f;
        }

        // No NavMesh point found — completely fallback
        return sourcePosition + Vector3.up * 1.0f;
    }


}




//using UnityEngine;
//using System.Collections.Generic;
//using System.Collections;

//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject Enemy1;
//    public GameObject Enemy2;
//    public GameObject Enemy3;
//    public GameObject Enemy4;
//    public GameObject Enemy5;
//    public int xPos1, xPos2, xPos3, xPos4, xPos5;
//    public int zPos1, zPos2, zPos3, zPos4, zPos5;
//    public int EnemyCount;

//    private void Start()
//    {
//        StartCoroutine(SpawnEnemies());

//    }

//    private IEnumerator SpawnEnemies()
//    {
//        while(EnemyCount < 4)
//        {
//            xPos1 = Random.Range(-40, -80);
//            zPos1 = Random.Range(50, 30);

//            xPos1 = Random.Range(0, -45);
//            zPos1 = Random.Range(13, -55);

//            xPos1 = Random.Range(0, -50);
//            zPos1 = Random.Range(40, 90);

//            xPos1 = Random.Range(-90, -30);
//            zPos1 = Random.Range(30, 60);

//            xPos1 = Random.Range(-25, -53);
//            zPos1 = Random.Range(0, 30);



//            Instantiate(Enemy1, new Vector3(xPos1, 4, zPos1), Quaternion.identity);
//            Instantiate(Enemy2, new Vector3(xPos2, 4, zPos2), Quaternion.identity);
//            Instantiate(Enemy3, new Vector3(xPos3, 4, zPos3), Quaternion.identity);
//            Instantiate(Enemy4, new Vector3(xPos4, 4, zPos4), Quaternion.identity);
//            Instantiate(Enemy5, new Vector3(xPos5, 4, zPos5), Quaternion.identity);
//            yield return new WaitForSeconds(5);
//            EnemyCount += 1;
//        }
//    }
//}

