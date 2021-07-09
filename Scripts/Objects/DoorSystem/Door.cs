using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int id;

    private void Start()
    {
        CustomEventSystem.current.onDoorwayTriggerEnter += OnDoorWayOpen;
        CustomEventSystem.current.onDoorwayTriggerExit += OnDoorWayClose;
    }

    private void OnDoorWayOpen(int id)
    {
        if (id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 5.5f, 2f).setEaseInCubic();
        }
    }

    private void OnDoorWayClose(int id)
    {
        if(id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 0.5f, 2f).setEaseOutCubic();
        }
    }
}
