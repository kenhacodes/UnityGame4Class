using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public GameObject door;
    public int Key_ID;
    public Inventory inventory;

    [HideInInspector]
    public int allitems;

    [HideInInspector]
    public GameObject itemManager;

    [HideInInspector]
    public GameObject usableItem;


    private void Start()
    {
        itemManager = GameObject.FindWithTag("ItemManager");

        allitems = itemManager.transform.childCount;
    }

    public void UnlockDoor()
    {
        for (int i = 0; i < allitems; i++)
        {
            if (itemManager.transform.GetChild(i).gameObject.activeSelf == true)
            {
                usableItem = itemManager.transform.GetChild(i).gameObject;

                if (usableItem.GetComponent<Item>().ID == Key_ID)
                {
                    door.SetActive(false);

                    for (int j = 0; j < inventory.allSlots; j++)
                    {
                        if (inventory.slots[j].GetComponent<Slot>().ID == Key_ID)
                        {
                            usableItem.SetActive(false);
                            inventory.slots[j].GetComponent<Slot>().ClearSlot();
                            return;
                        }
                    }
                    return;
                }
            }
        }
    }
}
