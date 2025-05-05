using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    Animator anim;
    Inventory invScript;

    public bool money;
    public int moneyAmount;

    public bool item;
    public GameObject itemIcon;

    bool pickedUp = false;
    

	// Use this for initialization
	void Start () {

        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        invScript = GameObject.FindWithTag("GameController").GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void OnTriggerStay(Collider player) {
        if (player.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.E) && !pickedUp)
            {
                pickedUp = true;
                StartCoroutine("PlayAnim");
            }
            
            /*
            if(money && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("PlayAnim");
            }
            else if(item && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("PlayAnim");
            }
            */
        }
	}

    IEnumerator PlayAnim()
    {
        anim.SetTrigger("pickup");
        yield return new WaitForSeconds(1);
       
        if (item)
        {
            GameObject i = Instantiate(itemIcon);
            i.transform.SetParent(invScript.invTab.transform);
            Destroy(gameObject);
        }
    }
}
