using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

    //info each item contains.

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
        itemIcon = Resources.Load<Texture2D>("Sprites/UI/Item Icons/" + name);
        itemGo = Resources.Load<GameObject>("Sprites/UI/Item Prefabs/" + name);
    }
    public Item()
    {

    }

} // Stina Hedman
