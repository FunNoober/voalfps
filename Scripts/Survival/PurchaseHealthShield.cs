using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseHealthShield : MonoBehaviour
{
    public PlayerHealhAndShield healthShield;

    public int cost;

    public SurvivalManager manager;

    public Text costText;

    private void Update()
    {
        costText.text = cost.ToString();
    }

    public void PurchaseHealth()
    {
        if(manager.score >= cost && healthShield.health < 100)
        {
            manager.score -= cost;
            healthShield.health = 100;
        }
    }

    public void PurchaseShield()
    {
        if(manager.score >= cost && healthShield.shield < 100)
        {
            manager.score -= cost;
            healthShield.shield = 100;
            healthShield.shieldActive = true;
        }
    }
}
