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
                
                if (MiniGameManager.instance.seaweedleft <= 0)
                {
                    AudioManager.instance.PlayOneShot(scrapPick, this.transform.position);
                    StatickSceneControler.CleaningMiniGameDown();
                    MiniGameManager.Parts ++;
                    /*if (MiniGameManager.Parts == 0)
                    {
                        print("levelToUnlode 1");
                        StatickSceneControler.CleaningMiniGameDown();
                        MiniGameManager.Parts ++;
                    }
                    if (MiniGameManager.Parts == 1)
                    {
                        print("levelToUnlode 2");
                        StatickSceneControler.CleaningMiniGameDown2();
                        MiniGameManager.Parts ++;
                    }
                    if (MiniGameManager.Parts == 2)
                    {
                        print("levelToUnlode 3");
                        StatickSceneControler.CleaningMiniGameDown3();
                        MiniGameManager.Parts ++;
                    }*/
                    
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
