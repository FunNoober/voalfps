using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staminia_s : MonoBehaviour
{
    public bool canRun;

    public float currentStaminia;

    public void h_Staminia(PlayerMovementStats stats, bool canRun)
    {
        if (currentStaminia <= 0)
        {
            canRun = false;
            StartCoroutine(GiveStaminia());
        }

        if (currentStaminia > 0)
        {
            canRun = true;
        }

        this.canRun = canRun;
        currentStaminia = Mathf.Clamp(currentStaminia, 0, stats.maxStamina);
    }

    private IEnumerator GiveStaminia()
    {
        yield return new WaitForSeconds(3);
        currentStaminia += Time.deltaTime;
    }
}
