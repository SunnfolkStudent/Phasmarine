using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

{
    // 20 funksjonerende i løsningen som skal ha en matchende ID med rutene (Ligger i tilfeldige posisjoner i starten og må rearangere på slutten)
    //foreach child return correct?
    
    public List<GameObject> TileListe = new List<GameObject> ();
    private float dampingSpeed;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;
    private MiniGameManager _miniGameManager;
    private PuzzleManager _puzzleManager;

    private GameObject lastPos;
    //passe på at den kun kan telle som korrekt en gang
    
    void Start()
    {
        _miniGameManager = GameObject.Find("Background").GetComponent<MiniGameManager>();
        _puzzleManager= GameObject.Find("Background").GetComponent<PuzzleManager>();
        
        float smallestdistance = 1000;
        foreach (var obj in TileListe)
        {
            float difference = Vector3.Distance(draggingObjectRectTransform.position, obj.transform.position);
            if (difference < smallestdistance)
            {
                smallestdistance = difference;
                CurrentTile = obj;
                nearestPos = obj.transform.position;
            }
        }

        CurrentTile.GetComponent<TileCheck>().Check(int.Parse(draggingObjectRectTransform.gameObject.name));
            _puzzleManager.Checkifworks();
    }

    private void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        float smallestdistance = 1000;
        foreach (var obj in TileListe)
        {
            float difference = Vector3.Distance(draggingObjectRectTransform.position, obj.transform.position);
            if ( difference < smallestdistance)
            {
                smallestdistance = difference;
                CurrentTile = obj;
                
            }
        }
        lastPos = CurrentTile;
        CurrentTile.GetComponent<TileCheck>().Occupied = false;
        CurrentTile.GetComponent<TileCheck>().IsCorrect = false;
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
                smallestdistance = difference;
                CurrentTile = obj;
                nearestPos = obj.transform.position;
            }
        }

        if (CurrentTile.GetComponent<TileCheck>().Occupied == false)
        {
            //snap to position  _iDscript.ID
            draggingObjectRectTransform.position = nearestPos; 
            //referere til tomme gameobject som tilecheck.check(tile-gameobject.name) draggingObjectRectTransform.gameObject.name.ToIntArray()[0]
          
            CurrentTile.GetComponent<TileCheck>().Check(int.Parse(draggingObjectRectTransform.gameObject.name));
            _puzzleManager.Checkifworks();
            //Checkifworks funker kun når starter på de første og vil kun gi en riktig
        }
        else
        {
            draggingObjectRectTransform.position = lastPos.transform.position;
            lastPos.GetComponent<TileCheck>().Check(int.Parse(draggingObjectRectTransform.gameObject.name));
        }
    }
       //Gi wiresene kode som navn
    }

