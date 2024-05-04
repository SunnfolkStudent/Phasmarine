using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWire : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private float dampingSpeed;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    private MiniGameManager _miniGameManager;

    public List<GameObject> TileListe = new List<GameObject>();

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position,
                eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position,
                globalMousePosition, ref velocity, dampingSpeed);
        }
    }

    Vector3 nearestPos;

    public void OnEndDrag(PointerEventData eventData)
    {
        //finne tile some er nærmest

        float smallestdistance = 1000;
        foreach (var obj in TileListe)
        {
            float difference = Vector3.Distance(draggingObjectRectTransform.position, obj.transform.position);
            if (difference < smallestdistance)
            {
                smallestdistance = difference;
                nearestPos = obj.transform.position;
            }
        }

        //snap to position 
        draggingObjectRectTransform.position = nearestPos;
    }
}
