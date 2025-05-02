using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  // For handling UI events

public class Inventory : MonoBehaviour
{
    public GameObject invTab;  // The inventory panel
    public static bool isOpen = false;

    // Use this for initialization
    void Start()
    {
        invTab.SetActive(false);
        // Set cursor settings for the start of the game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle inventory when Tab is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        invTab.SetActive(isOpen);

        if (isOpen)
        {
            // Show the cursor and unlock it when the inventory is open
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;  // Pause the game while the inventory is open

            // Make sure the EventSystem can interact with UI elements
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            // Hide the cursor and lock it when the inventory is closed
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;  // Resume the game when the inventory is closed
        }
    }

    // Optional: Handling clicks on inventory objects
    public void UseItem(GameObject item)
    {
        // Logic for using an item in the inventory
        Debug.Log("Used item: " + item.name);
    }
}
