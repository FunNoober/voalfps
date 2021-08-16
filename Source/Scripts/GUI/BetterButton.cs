using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BetterButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public float animTime = 0.1f;
    public Vector3 scaleToTweenTo = new Vector3(1.2f, 1.2f, 1.2f);
    public UnityEvent onClicked;
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private Vector3 startSize;

    private void Awake()
    {
        startSize = this.gameObject.transform.localScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClicked?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onEnter?.Invoke();
        LeanTween.scale(this.gameObject, scaleToTweenTo, animTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onExit?.Invoke();
        LeanTween.scale(this.gameObject, startSize, animTime);
    }
}
