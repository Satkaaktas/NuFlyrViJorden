using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    
    public List<Item> inventory = new List<Item>();
    private ItemDatabase database;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    public void OnGUI()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            GUI.Label(new Rect(10, i * 10, 200, 50), inventory[i].itemName);
        }
    }
}
