using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManagerScript : MonoBehaviour
{
    public bool HasWeaponOnStart = false;

    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI WeaponText;

    public int ZeroAmmo = 00;

    public string AmountToDisplay;
    public string WeaponToDisplay;

    void Start()
    {
        if(HasWeaponOnStart == false)
        {
            AmmoText.text = AmountToDisplay;
            WeaponText.text = WeaponToDisplay;
        }
    }


}
