﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    //list of all items in game
    List<Item> items = new List<Item>();

    public List<Item> Items
    {
        get { return this.items; }
    }

    private void Start()
    {
        items.Add(new Item("Hammer", 0, "and my hammer"));
        items.Add(new Item("Shovel", 1, "Dig dig dug"));
        items.Add(new Item("Cup", 2, "The holy cup"));
    }
}