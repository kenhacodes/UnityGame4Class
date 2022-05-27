using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    public Transform slotIconGameObject;
    public Sprite slotIconDefault;

    private void Start()
    {
        slotIconGameObject = transform.GetChild(0);
        slotIconDefault = slotIconGameObject.GetComponent<Image>().sprite;
    }

    public void UpdateSlot()
    {
        Debug.Log("Esto tiene que ser un sprite " + icon);

        slotIconGameObject.GetComponent<Image>().sprite = icon;

        Debug.Log("Esto tiene que seguir siendo un sprite " + slotIconGameObject.GetComponent<Image>().sprite);
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }

    public void ClearSlot()
    {
        ID = 0;
        type = null;
        description = null;
        icon = null;
        empty = true;
        Destroy(item);
        slotIconGameObject.GetComponent<Image>().sprite = slotIconDefault;
    }
}
