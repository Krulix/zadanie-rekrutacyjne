using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RodRotationController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Action<float> rotateAction;
    private bool mouseDown;
    private float lastMouseXpos;

    public void SetRotateAction(Action<float> action)
    {
        rotateAction += action;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseDown = true;
        lastMouseXpos = Input.mousePosition.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        mouseDown = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rotateAction != null && mouseDown)
        {
            rotateAction(lastMouseXpos - Input.mousePosition.x);
            lastMouseXpos = Input.mousePosition.x;
        }
    }
}
