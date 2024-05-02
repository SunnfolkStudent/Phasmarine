using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
   private List<EventInstance> eventInstances;

   private EventInstance ambienceEventInstance;
   
   private EventInstance eerieEventInstance;
   
   private EventInstance playerDiedEventInstance;
   
   public static AudioManager instance { get; private set; }

   private void Awake()
   {
      if (instance != null) 
      {
         Debug.LogError("Found more than one Audio Manager in the scene.");
      }
      instance = this;

      eventInstances = new List<EventInstance>();

   }

   private void Start()
   {
      InitializeAmbience(FMODEvents.instance.ambience);
      InitializeEerie(FMODEvents.instance.eerie);
      InitializeplayerDied(FMODEvents.instance.playerDied);
   }

   private void InitializeAmbience(EventReference ambienceEventReference)
   {
      ambienceEventInstance = CreateInstance(ambienceEventReference);
      ambienceEventInstance.start();
   }

   private void InitializeEerie(EventReference eerieEventReference)
   {
      eerieEventInstance = CreateInstance(eerieEventReference);
      eerieEventInstance.start();
   }

   private void InitializeplayerDied(EventReference playerDiedEventReference)
   {
      playerDiedEventInstance = CreateInstance(playerDiedEventReference);
      playerDiedEventInstance.start();
   }

   public EventInstance CreateInstance(EventReference eventReference)
   {
      EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
      eventInstances.Add(eventInstance);
      return eventInstance;
   }

   public void PlayOneShot(EventReference sound, Vector3 worldPos)
   {
      RuntimeManager.PlayOneShot(sound,worldPos);
   }

   private void CleanUp()
   {
      // stop and release any created instances
      foreach (EventInstance eventInstance in eventInstances)
      {
         eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
         eventInstance.release();
      }
      
   }

   private void OnDestroy()
   {
      CleanUp();
   }
   
}
