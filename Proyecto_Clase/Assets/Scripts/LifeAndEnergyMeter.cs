using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeAndEnergyMeter : MonoBehaviour
{
    public Image livingMeter;
    public float living;
    public float maxHealth;
    public bool countDown;

    public Image energyMeter;
    public float energy;
    public float maxEnergy;
    public bool isMaxEnergy;

    void Update()
    {
        livingMeter.fillAmount = living / maxHealth;

        energyMeter.fillAmount = energy / maxEnergy;

        if (countDown)
        {
            living -= Time.deltaTime;
        }

        if (living < 0)
        {
            countDown = false;
            living = 0;
        }

        if (energy >= maxEnergy)
        {
            isMaxEnergy = true;
        }
        else
        {
            isMaxEnergy = false;
        }

        if (energy < 0)
        {
            energy = 0;
        }
    }

    public void HealthUp(float health)
    {
        living += health;
    }
    public void ConsumeFood(GameObject food)
    {
        Destroy(food);
    }
}
