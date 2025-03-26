using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject invTab;
    //
    private bool isOpen = false;

	// Use this for initialization
	void Start () {
        invTab.SetActive(false);
        //
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        /*
        if (Input.GetKey(KeyCode.Tab))
        {
            invTab.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            invTab.SetActive(false);
            Cursor.visible = false;
        }
        */
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
	}

    void ToggleInventory()
    {
        isOpen = !isOpen;
        invTab.SetActive(isOpen);

        if(isOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
}
