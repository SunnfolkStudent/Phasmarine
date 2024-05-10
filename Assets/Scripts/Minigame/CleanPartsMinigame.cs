using UnityEngine;
using UnityEngine.EventSystems;

public class CleanPartsMinigame : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Vector3 mousePosition;
    private MiniGameManager _miniGameManager;
    private RectTransform _rectTransform;
    public GameObject selectedObject;
    private int seaweed = 7;
    public Vector3 offset;

    void Start()
    {
        //Hvordan dra på UI i canvas må bruke rectransform
        _rectTransform = GetComponent<RectTransform>();
        //parent is the part and child is the seaweed thus localposition
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        selectedObject = eventData.selectedObject;
        offset = selectedObject.transform.position - mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (selectedObject.transform.localPosition.magnitude >=20)
        {
            selectedObject.SetActive(false);
            seaweed -= 1;
            if (seaweed == 0)
            {
                StatickSceneControler.CleaningMiniGameDown();
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
            //Calculate the distance between the Camera and the GameObject, and go this distance along the ra
            //Move the GameObject when you drag it
            _rectTransform.position = mousePosition + offset;;
        }


    //ontriggerstay2D(når den drar fra collideren rundt triggere minigamedown
}
