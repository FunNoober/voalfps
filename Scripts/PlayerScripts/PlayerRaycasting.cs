using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public SurvivalManager manager;
    public float maxDistance;
    public LayerMask Everything;
    
    public KeyCode use;
    void Update()
    {
        if(Input.GetKeyDown(use))
        {
             RaycastHit HitInfo;
             if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out HitInfo, Mathf.Infinity, Everything))
             {
                 if(HitInfo.collider.tag == "WeaponPickUp")
                 {
                     GunPickUp theGunToBuy = HitInfo.collider.GetComponent<GunPickUp>();
                     if(theGunToBuy != null && theGunToBuy.ScoreToBuy >= manager.score)
                     {
                         Debug.Log("A gun has been purchased");
                         theGunToBuy.SetParent();
                         manager.score -= theGunToBuy.ScoreToBuy;
                     }
                 }
                Debug.Log(HitInfo.collider.tag);
             }
        }
    }
}
