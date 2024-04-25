using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }
   
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambience { get; private set; }
    
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference footstepsMetal { get; private set; }
    [field: SerializeField] public EventReference footstepsSand { get; private set; }
    [field: SerializeField] public EventReference breathing { get; private set; }
    [field: SerializeField] public EventReference hurt { get; private set; }
   
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
