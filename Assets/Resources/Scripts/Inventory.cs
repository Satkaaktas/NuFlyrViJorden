using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //List of items in the inventory
    public List<Item> inventory = new List<Item>();

    //List of items visualised in inventorySlots
    public List<Item> inventorySlots = new List<Item>();

    private AudioClip invOpenSound, invCloseSound;

    //reference to database
    private ItemDatabase database;

    bool showInventory;

    public int slotsX = 2, slotsY = 5;

    public static Inventory instance;

    //-----------------------------------------    TILLSVIDARE   ------------------------------------------------------------------------------------------------------------------------------
    int indexitem = 0;
    //-----------------------------------------    TILLSVIDARE   ------------------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        //kolla om en instans av soundmanager redan är i scenen.
        if (instance == null)
        {
            instance = this;
        }

        //ser till att det bara är en soundmanager instansierad.
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        showInventory = false;

        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();

        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            inventory.Add(new Item());
            inventorySlots.Add(new Item());

        }

        invOpenSound = Resources.Load<AudioClip>("Audio/Inventory/openInv");
        invCloseSound = Resources.Load<AudioClip>("Audio/Inventory/closeInv");
    }


    void Update()
    {

        //open and close inventory.
        if (Input.GetButtonDown("Inventory"))
        {
            if (!showInventory)
            {
                Debug.Log("inventory Open");
                SoundManager.instance.PlaySingle(invOpenSound);
                showInventory = true;
            }

            else
            {
                Debug.Log("inventory Closed");
                SoundManager.instance.PlaySingle(invCloseSound);
                showInventory = false;
            }
        }

        //-----------------------------------------    TILLSVIDARE Lägger till och ta bort item i inventory ---------------------------------------------------------------


        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1) && indexitem <= 2 && indexitem >= 0)
        {
            inventory[indexitem] = database.Items[indexitem];
            indexitem++;
            Debug.Log("Item added. indexitem = " + indexitem);

            if (Input.GetKeyDown(KeyCode.Keypad1) && indexitem < 1 && indexitem >= 0)
            {
                inventory[indexitem] = database.items[indexitem];
                indexitem++;
                Debug.Log("Item added. indexitem = " + indexitem);



            }

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha2) && indexitem >= 1 && indexitem <= 3)
            {
                RemoveItem(database.Items[indexitem - 1]);
                indexitem--;
                Debug.Log("item removed. indexitem = " + indexitem);
            }

            //-----------------------------------------    TILLSVIDARE   -------------------------------------------------------------------------------------------------------
        }
    }

    //creates inventory if Inventorykey is pressed.
    private void OnGUI()
    {
        if (showInventory)
        {
            GUI.DrawTexture(new Rect(0, 0, 350, 350), Resources.Load<Texture2D>("Sprites/UI/InventoryBackground"), ScaleMode.ScaleToFit);

            OpenInventory();
        }
    }


    // creates the inventory and loads in items.
    public void OpenInventory()
    {
        int i = 0;

        for (int y = 1; y < slotsY + 1; y++)
        {
            for (int x = 1; x < slotsX + 1; x++)
            {
                Rect slotRect = new Rect((x * 75) + 20, (y * 40) + 70, 75, 75);

                GUI.Box(slotRect, Resources.Load<Texture2D>("Sprites/UI/InventorySlot"), GUIStyle.none);

                if (inventory[i].itemName != null)
                {
                    GUI.Box(slotRect, inventory[i].itemIcon, GUIStyle.none);

                }

                i++;
            }
        }

    }


    // used to remove item from inventory by itemname.
    public void RemoveItem(Item item)
    {
        int removeIndex = -1;

        removeIndex = inventory.FindIndex(i => i.itemID == item.itemID);

        if (removeIndex != -1)
        {
            inventory[removeIndex] = new Item();
        }

    }


    //OM MAN BARA SPARAR ID KAN VI LÄGGA TILL ITEM via database.items[ID] -----------------------------------------------------------------------------------------------------------------------------
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }
 }

