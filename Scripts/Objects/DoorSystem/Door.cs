using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Door : MonoBehaviour
{
    public int id;

    public float tweenUpAmount = 5.5f;
    public float tweenDownAmount = 0.5f;

    public enum DoorType
    {
        Open,
        Destroy
    }

    public DoorType dP;

    private void Start()
    {
        CustomEventSystem.current.onDoorwayTriggerEnter += OnDoorWayOpen;
        CustomEventSystem.current.onDoorwayTriggerExit += OnDoorWayClose;
    }

    private void OnDoorWayOpen(int id)
    {
        if (id == this.id)
        {
            if(dP == DoorType.Open)
                LeanTween.moveLocalY(gameObject,tweenUpAmount, 2f).setEaseInCubic();
            if (dP == DoorType.Destroy)
                gameObject.SetActive(false);
        }
    }

    private void OnDoorWayClose(int id)
    {
        if(id == this.id)
        {
            if(dP == DoorType.Open)
                LeanTween.moveLocalY(gameObject, tweenDownAmount, 2f).setEaseOutCubic();
            if (dP == DoorType.Destroy)
                gameObject.SetActive(true);
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
