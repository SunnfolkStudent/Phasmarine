using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambience { get; private set; }
    
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference footstepsMetal { get; private set; }
    [field: SerializeField] public EventReference breathing { get; private set; }
    
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
