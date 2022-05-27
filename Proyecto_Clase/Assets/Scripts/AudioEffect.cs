using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    public AudioSource audioEffect;

    public void PlayEffect()
    {
        audioEffect.Play();
    }
}
