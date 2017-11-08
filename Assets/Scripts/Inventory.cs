﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    //List of items in the inventory
    public List<Item> inventory = new List<Item>();

    //List of items visualised in inventorySlots
    public List<Item> inventorySlots = new List<Item>();

    private ItemDatabase database;

    bool showInventory;

    public int slotsX, slotsY;

    //-----------------------------------------    TILLSVIDARE   ------------------------------------------------
    int indexitem = 0;
    //-----------------------------------------    TILLSVIDARE   ------------------------------------------------

    void Start () {

        showInventory = false;

        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();

        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            inventory.Add(new Item());
            inventorySlots.Add(new Item());

        }
    }

    void Update () {

        //open and close inventory.
        if (Input.GetButtonDown("Inventory"))
        {
            if (!showInventory)
            {
                Debug.Log("inventory Open");
                showInventory = true;
            }

            else
            {
                Debug.Log("inventory Closed");
                showInventory = false;
            }
        }

        //-----------------------------------------    TILLSVIDARE   ------------------------------------------------

        if (Input.GetKeyDown(KeyCode.Keypad1) && indexitem <= 2 && indexitem >= 0)
        {
            inventory[indexitem] = database.items[indexitem];
            indexitem++;
            Debug.Log("Item added. indexitem = " + indexitem);
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad2) && indexitem >= 1 && indexitem <= 3)
        {
            RemoveItem(database.items[indexitem-1]);
            indexitem--;
            Debug.Log("item removed. indexitem = " + indexitem);
        }

        //-----------------------------------------    TILLSVIDARE   ------------------------------------------------
    }

    private void OnGUI()
    {
        if (showInventory)
        {
            OpenInventory();
        }
    }

    public void OpenInventory()
    {
        int i = 0;

        for (int y = 0; y < slotsY; y++) 
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 50, y * 50, 100, 100);

                GUI.Box(slotRect, Resources.Load<Texture2D>("UI/InventorySlot"), GUIStyle.none);

                if (inventory[i].itemName != null)
                {
                    GUI.Box(slotRect, inventory[i].itemIcon, GUIStyle.none);

                }  

                i++;
            }
        }
        
    }

    public void RemoveItem(Item item)
    {
        int removeIndex = -1;

        removeIndex = inventory.FindIndex(i => i.itemID == item.itemID);

        if (removeIndex != -1)
        {
            inventory[removeIndex] = new Item();
        }

    }
}