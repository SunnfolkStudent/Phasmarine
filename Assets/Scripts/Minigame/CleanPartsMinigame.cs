using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class CleanPartsMinigame : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private MiniGameManager _miniGameManager;
    private RectTransform _rectTransform;
    public GameObject selectedObject;
    private int seaweed = 7;

    void Start()
    {
        //Hvordan dra på UI i canvas må bruke rectransform
        _rectTransform = GetComponent<RectTransform>();
        //parent is the part and child is the seaweed thus localposition
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        selectedObject = eventData.selectedObject;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (selectedObject.transform.localPosition.magnitude >=3)
        {
            selectedObject.SetActive(false);
            seaweed -= 1;
            if (seaweed == 0)
            {
                _miniGameManager.CleaningMiniGameDown();
            }
        }
        //else
        {
            //Stay at the pos
        }
        //If far enough away make the gameobject dissapear
    }
    
    public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging");
            //Create a ray going from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(eventData.position);
            //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
            Vector3 rayPoint = ray.GetPoint(Vector3.Distance(_rectTransform.position, Camera.main.transform.position));
            //Move the GameObject when you drag it
            _rectTransform.position = rayPoint;
        }

}
