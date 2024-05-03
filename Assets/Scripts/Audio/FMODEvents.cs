using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Music")]
    
    [field: SerializeField] public EventReference mainMenu { get; private set; }
    [field: SerializeField] public EventReference tutorial { get; private set; }
    [field: SerializeField] public EventReference level1 { get; private set; }
   
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambience { get; private set; }
    
    [field: Header("Death")]
    [field: SerializeField] public EventReference playerDied { get; private set; }
    
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference footstepsMetal { get; private set; }
    [field: SerializeField] public EventReference footstepsSand { get; private set; }
    [field: SerializeField] public EventReference breathing { get; private set; }
    [field: SerializeField] public EventReference hurt { get; private set; }
    [field: SerializeField] public EventReference heartbeat { get; private set; }
    [field: SerializeField] public EventReference scrapPick { get; private set; }
    [field: SerializeField] public EventReference stun { get; private set; }
    [field: SerializeField] public EventReference nostun { get; private set; }
    
    [field: Header("Minigame")]
    [field: SerializeField] public EventReference klokkeFeil { get; private set; }
    [field: SerializeField] public EventReference klokkeRiktig { get; private set; }
    
    [field: Header("MinigameMusic")]
    [field: SerializeField] public EventReference minigameMusic { get; private set; }
    
    [field: Header("Eerie")]
    [field: SerializeField] public EventReference eerie { get; private set; }
    
    public static FMODEvents instance { get; private set; }

    private void Awake() 
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events script in the scene");
        }

        instance = this;
    }
}
