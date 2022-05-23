using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMeter : MonoBehaviour
{
    public Image livingMeter;
    public float living;
    public float maxHealth;

    void Update()
    {
        livingMeter.fillAmount = living / maxHealth;
    }
}
