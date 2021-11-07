using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    [SerializeField] Canvas canvas;

    private static float canvasScaleFactor = 1;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Debug.Log(canvasScaleFactor);
        rectTransform.anchoredPosition += eventData.delta / canvasScaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }

    public static void SetCanvasScaleFactor(float newScale)
    {
        canvasScaleFactor = newScale;
    }
}
