using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using funNoober.UnRewroteUtilities;

public class CameraInteract : MonoBehaviour
{
    public GameObject interactTooltip;

    private StarndardActions actions;

    private void Awake()
    {
        actions = new StarndardActions();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Update()
    {
        if(actions.StarndardInput.Interact.triggered)
        {
            GetInteractObject();
        }
    }

    public void GetInteractObject()
    {
        GameObject hitObject = UnRewroteUtilities.RayCastUtilities.GetHitObject(transform, 10f);
        if (hitObject != null)
        {
            IInteract interactable = hitObject.GetComponent<IInteract>();
            if (interactable != null)
            {
                interactable.InteractWith();
            }
        }
    }
}
