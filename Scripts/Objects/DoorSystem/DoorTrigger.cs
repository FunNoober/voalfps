using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        CustomEventSystem.current.DoorwayTriggerEnter(id);
    }

    private void OnTriggerExit(Collider other)
    {
        CustomEventSystem.current.DoorwayTriggerExit(id);
    }
}
