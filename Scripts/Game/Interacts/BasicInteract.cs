using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BasicInteract : MonoBehaviour, IInteract
{
    public UnityEvent OnInteract;
    public GameObject interactTooltip;

    public void InteractWith()
    {
        OnInteract?.Invoke();
    }

    public void Hover()
    {
        interactTooltip?.SetActive(true);
    }

    public void Exit()
    {
        interactTooltip?.SetActive(false);
    }
}
