using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DustZone : MonoBehaviour
{
    public PlayerHealhAndShield player;

    public bool inTrigger;

    public RawImage dustFX;

    public Color dustFullColor;

    private void Update()
    {
        if (inTrigger)
        {
            player.health -= (int)Time.deltaTime;
            player.shield -= (int)Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inTrigger = true;
        }

        dustFX.color = Color.Lerp(dustFX.color, dustFullColor, .9f) ;       
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}
