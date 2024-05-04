using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.EventSystems;
using FMODUnity;

public class DragAndDrop : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private float dampingSpeed;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    private bool draggable = true;
    private MiniGameManager _miniGameManager;
    [SerializeField] private EventReference scrapPick;

    private Vector2 minmaxX = new Vector2(-500, 450);
    private Vector2 minmaxY = new Vector2(-500, 650);
    
    void Start()
    {
        _miniGameManager = GameObject.Find("Part").GetComponent<MiniGameManager>();
    }

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
    }

    private bool hasbeencounted = false;
    private void Update()
    {
        if (draggingObjectRectTransform.localPosition.x > minmaxX.y || 
            draggingObjectRectTransform.localPosition.x < minmaxX.x ||
            draggingObjectRectTransform.localPosition.y > minmaxY.y || 
            draggingObjectRectTransform.localPosition.y < minmaxY.x)
        {
            if (hasbeencounted == false)
            {
                hasbeencounted = true;
                MiniGameManager.instance.seaweedleft -= 1;
                Debug.Log(MiniGameManager.instance.seaweedleft);
                draggable = false;
                
                if (MiniGameManager.instance.seaweedleft == 0)
                {
                    AudioManager.instance.PlayOneShot(scrapPick, this.transform.position);
                    Debug.Log("Seaweed collider");
                    if (MiniGameManager.Parts == 0)
                    {
                        _miniGameManager.CleaningMiniGameDown();
                    }
                    if (MiniGameManager.Parts == 1)
                    {
                        _miniGameManager.CleaningMiniGameDown2();
                    }
                    if (MiniGameManager.Parts == 2)
                    {
                        _miniGameManager.CleaningMiniGameDown3();
                    }
                    MiniGameManager.Parts += 1;
                }
                
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
