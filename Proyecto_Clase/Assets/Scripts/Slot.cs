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

    private void Start()
    {
        slotIconGameObject = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        Debug.Log("Esto es un sprite: "+icon);

        slotIconGameObject.GetComponent<Image>().sprite = icon;

        Debug.Log("Este es el icono: "+ slotIconGameObject.GetComponent<Image>().sprite);
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }
}
