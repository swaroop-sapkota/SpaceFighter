using UnityEngine;

public class EnemyKillTracker : MonoBehaviour
{
    public static int dragonKillCount = 0;
    public static int requiredDragonKills = 10; // You can change this number

    public static void AddKill()
    {
        dragonKillCount++;
        Debug.Log("Dragon killed! Total: " + dragonKillCount);
    }

    public static bool HasKilledEnough()
    {
        return dragonKillCount >= requiredDragonKills;
    }
}
