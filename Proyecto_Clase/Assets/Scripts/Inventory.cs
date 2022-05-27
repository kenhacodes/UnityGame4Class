using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject descPanel;
    public GameObject slotHander;

    [HideInInspector]
    public bool inventoryEnabled;

    [HideInInspector]
    public int allSlots;

    int enabledSlots;

    [HideInInspector]
    public GameObject[] slots;


    void Start()
    {
        allSlots = slotHander.transform.childCount;

        slots = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slots[i] = slotHander.transform.GetChild(i).gameObject;

            if (slots[i].GetComponent<Slot>().item == null)
            {
                slots[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }


    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Item"))
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }
    */

    public void GetItem(GameObject other)
    {
        if (other.tag.Equals("Item"))
        {
            Item item = other.GetComponent<Item>();

            AddItem(other, item.ID, item.type, item.description, item.icon);
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDesc, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slots[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slots[i].GetComponent<Slot>().item = itemObject;
                slots[i].GetComponent<Slot>().ID = itemID;
                slots[i].GetComponent<Slot>().type = itemType;
                slots[i].GetComponent<Slot>().description = itemDesc;
                slots[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slots[i].transform;
                itemObject.SetActive(false);

                slots[i].GetComponent<Slot>().UpdateSlot();

                slots[i].GetComponent<Slot>().empty = false;

                return;
            }
        }
    }
}
