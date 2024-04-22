using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler
{
    [SerializeField] 
    private float dampingSpeed = 0.5f;
    private int seaweedleft = 7;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    private MiniGameManager _miniGameManager;
    void Start()
    {
        _miniGameManager = GetComponent<MiniGameManager>();
    }

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position,
                eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position,
                globalMousePosition, ref velocity, dampingSpeed);
        }
    }
    
    
    void OnTriggerExit(Collider other)
    {
        seaweedleft -= 1;
        if (seaweedleft == 0)
        {
            _miniGameManager.CleaningMiniGameDown();
        }
        //Destroy(other.gameObject);
    }
}
