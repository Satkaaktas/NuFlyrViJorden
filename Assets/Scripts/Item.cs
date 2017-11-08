﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

    public string itemName;
    public int itemID;
    public string itemDesc;
    public Texture2D itemIcon;
    public GameObject itemGo;

    public Item(string name, int id, string desc)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
        itemGo = Resources.Load<GameObject>("Item Prefabs/" + name);
    }
    public Item()
    {

    }

}