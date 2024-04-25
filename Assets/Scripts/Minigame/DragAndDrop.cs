using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler
{
    [SerializeField] 
    private float dampingSpeed;
    private int seaweedleft = 7;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    private bool draggable = true;
    private MiniGameManager _miniGameManager;

    [SerializeField] private Vector2 minmaxX = new Vector2(-250, 250);
    [SerializeField] private Vector2 minmaxY = new Vector2(-250, 250);
    
    void Start()
    {
        _miniGameManager = GameObject.Find("Part").GetComponent<MiniGameManager>();
    }

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
    }

    private void Update()
    {
        if (draggingObjectRectTransform.position.x > minmaxX.y || 
            draggingObjectRectTransform.position.x < minmaxX.x ||
            draggingObjectRectTransform.position.y > minmaxY.y || 
            draggingObjectRectTransform.position.y < minmaxY.x)
        {
            if (draggable) 
                //Want to make the current object only count once
            { seaweedleft -= 1;
                Debug.Log(seaweedleft);
                draggable = false;}
            
            
            if (seaweedleft == 0)
            {
                Debug.Log("Seaweed collider");
                _miniGameManager.CleaningMiniGameDown();
                
            }
            
        }
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
    
}
