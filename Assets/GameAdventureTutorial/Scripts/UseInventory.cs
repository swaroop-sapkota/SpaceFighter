using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class UseInventory : MonoBehaviour
{

    public bool stats;
    public bool item;
    public bool health;

    public int tValue;
    public int hValue;
    public int healthValue;

    GameObject inv;
    GameObject player;


    void Start()
    {
        inv = GameObject.FindWithTag("GameController");
        player = GameObject.FindWithTag("Player");
    }

    public void UseItem()
    {
        if (stats)
        {
            player.GetComponent<ThirdPersonCharacter>().thirst += tValue;
            player.GetComponent<ThirdPersonCharacter>().hunger += hValue;
            Destroy(gameObject);
        }

        if (item)
        {
            //use item
        }
        if (health)
        {
            player.GetComponent<ThirdPersonCharacter>().health += hValue;

        }
    }
}
