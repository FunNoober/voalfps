using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour, IPointerClickHandler ,IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent clickedEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickedEvent?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(this.gameObject, new Vector3(1.25f, 1.25f, 1.25f), 0.5f).setIgnoreTimeScale(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(this.gameObject, new Vector3(1, 1, 1), 0.5f).setIgnoreTimeScale(true);
    }
}
