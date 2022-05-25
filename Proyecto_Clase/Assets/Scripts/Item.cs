using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;

    [HideInInspector]
    public GameObject itemManager;

    [HideInInspector]
    public GameObject descText;

    [HideInInspector]
    public GameObject usableItem;

    public bool playerItem;

    private void Start()
    {
        itemManager = GameObject.FindWithTag("ItemManager");
        descText = GameObject.FindWithTag("DescText");

        if (!playerItem)
        {
            int allitems = itemManager.transform.childCount;

            for (int i = 0; i < allitems; i++)
            {
                if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    usableItem = itemManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void Update()
    {
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                equipped = false;
            }
            if (equipped == false)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ItemUsage()
    {
        descText.GetComponent<Text>().text = description;

        if (type.Equals("Usable"))
        {
            usableItem.SetActive(true);

            usableItem.GetComponent<Item>().equipped = true;
        }
    }
}
