using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
   private List<EventInstance> eventInstances;
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

   public EventInstance CreateInstance(EventReference eventReference)
   {
      EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
      eventInstances.Add(eventInstance);
      return eventInstance;
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
