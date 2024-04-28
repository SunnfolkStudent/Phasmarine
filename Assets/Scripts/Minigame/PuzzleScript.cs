using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine;using UnityEngine.EventSystems;

public class PuzzleScript : MonoBehaviour, IDragHandler, IEndDragHandler

{
    // 20 funksjonerende i løsningen som skal ha en matchende ID med rutene (Ligger i tilfeldige posisjoner i starten og må rearangere på slutten)
    //foreach child return correct?
    
    public List<GameObject> TileListe = new List<GameObject> ();
    private float dampingSpeed;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    private bool draggable = true;
    private MiniGameManager _miniGameManager;
    private IDscript _iDscript;
    
    public int counter = 0;
    //passe på at den kun kan telle som korrekt en gang
    
    void Start()
    {
        _miniGameManager = GameObject.Find("Background").GetComponent<MiniGameManager>();
        _iDscript.GetComponent<IDscript>();
    }

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
    }

    private bool hasbeencounted = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position,
                eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position,
                globalMousePosition, ref velocity, dampingSpeed);
        }
    }
    
    //Skjer på dragrelease
    public void Checkifworks()
    {
        counter = 0;
        foreach (var obj in TileListe)
        {
            if(obj.GetComponent<TileCheck>().IsCorrect)
            {
                Debug.Log("One right");
                counter++;
            }
            else
            {
                counter = 0;
                break;
            }
        }
        if (counter == 20)
        {
            Debug.Log("All right");
            _miniGameManager.PuzzleMiniGameDown();
        }
        
    }

    [HideInInspector] public GameObject CurrentTile;
    [HideInInspector] public Vector3 nearestPos;
    public void OnEndDrag(PointerEventData eventData)
    {
        //finne tile some er nærmest
        
        float smallestdistance = 1000;
        foreach (var obj in TileListe)
        {
            float difference = Vector3.Distance(draggingObjectRectTransform.position, obj.transform.position);
            if ( difference < smallestdistance)
            {
                Debug.Log("found closer tile");
                smallestdistance = difference;
                CurrentTile = obj;
                nearestPos = obj.transform.position;
            }
        }
        //snap to position  _iDscript.ID
        draggingObjectRectTransform.position = nearestPos; 
        //referere til tomme gameobject som tilecheck.check(tile-gameobject.name) draggingObjectRectTransform.gameObject.name.ToIntArray()[0]
          
        CurrentTile.GetComponent<TileCheck>().Check(int.Parse(draggingObjectRectTransform.gameObject.name));
        Checkifworks();
        //Checkifworks funker ikke kan være fordi den ikke får informasjonen fra den andreoperasjonen
    }
       //Gi wiresene kode som navn
    }

