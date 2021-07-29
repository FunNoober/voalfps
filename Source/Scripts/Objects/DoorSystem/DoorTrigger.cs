using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.blue;
        style.fontSize = 25;

        Handles.Label(transform.position, id.ToString(), style);
    }
#endif
}
