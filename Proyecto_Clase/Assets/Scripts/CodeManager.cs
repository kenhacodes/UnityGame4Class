using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeManager : MonoBehaviour
{
    public GameObject codeGeneral;
    public Text PanelCode;
    public string correctCode;
    public GameObject thingToDestroy;

    string number;
    int comp = 0;
    [HideInInspector]
    public bool isActive;

    private void Awake()
    {
        codeGeneral.SetActive(false);
        isActive = false;
    }

    public void Prepare()
    {
        isActive = true;
        codeGeneral.SetActive(true);
    }

    public void buttonPressed(GameObject button)
    {
        number = button.transform.GetChild(0).GetComponent<Text>().text;

        PanelCode.text += number;

        comp += 1;
    }

    private void Update()
    {
        if (comp == 4)
        {
            if (PanelCode.text.Equals(correctCode))
            {
                Destroy(thingToDestroy);
                codeGeneral.SetActive(false);
                isActive = false;
            }
            else
            {
                PanelCode.text = "";
                comp = 0;
            }
        }
    }
}
