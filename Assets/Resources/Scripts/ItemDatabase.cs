using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    //list of all items in game
    public List<Item> items = new List<Item>();

    private void Start()
    {
        items.Add(new Item("Hammer", 0, "and my hammer"));
        items.Add(new Item("Shovel", 1, "Dig dig dug"));
        items.Add(new Item("Cup", 2, "The holy cup"));
    }
}

// Stina Hedman