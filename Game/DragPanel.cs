using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Vector2 pointerOffset;
    private RectTransform canvasRectTransform;
    private RectTransform panelRectTransform;

    [HideInInspector]
    public bool isDragging = false;

    void Awake()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.transform as RectTransform;
            panelRectTransform = transform as RectTransform;
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        isDragging = true;
    }

    public void OnPointerDown(PointerEventData data)
    {
        panelRectTransform.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);
        isDragging = true;
        GameObject.Find("Cube").GetComponent<RotarConTouch>().enabled = false;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("They began dragging " + this.name);
        GameObject.Find("Cube").GetComponent<RotarConTouch>().enabled = false;
    }

    public void OnDrag(PointerEventData data)
    {
        if (panelRectTransform == null)
            return;

        // Vector2 pointerPostion = ClampToWindow(data);
        Vector2 localPointerPosition;
        

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform, data.position, data.pressEventCamera, out localPointerPosition
        ))
        {
            panelRectTransform.localPosition = localPointerPosition - pointerOffset;
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        isDragging = false;
    }

    void Update()
    {
        if((isDragging == false))
        {
            GameObject.Find("Cube").GetComponent<RotarConTouch>().enabled = true;
        }
    }
}