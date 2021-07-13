using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 25;

        Handles.Label(transform.position + new Vector3(0,2,0), id.ToString(), style);
    }
#endif
}
