using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
   private List<EventInstance> eventInstances;

   private EventInstance ambienceEventInstance;
   
   private EventInstance eerieEventInstance;

   private EventInstance mainMenuEventInstance;
   
   private EventInstance tutorialEventInstance;
   
   private EventInstance levelsEventInstance;
   
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
      //if scene is not mainmenu activate eerie
      if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
      {
         if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Tutorial"))
         {
            InitializeEerie(FMODEvents.instance.eerie);
         }
      }
      
      //mainmenu plays ambience and mainmenu theme
      if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
      {
         InitializemainMenu(FMODEvents.instance.mainMenu);
         InitializeAmbience(FMODEvents.instance.ambience);
         
         
      }
      
      //tutorial plays ambience and tutorial theme
      if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial"))
      {
         InitializeTutorial(FMODEvents.instance.tutorial);
         InitializeAmbience(FMODEvents.instance.ambience);
      }
      
      //levelone plays ambience and levels themes
      if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelOne"))
      {
         InitializeLevels(FMODEvents.instance.levels);
         InitializeAmbience(FMODEvents.instance.ambience);
      }
      
      //leveltwo plays ambience and levels themes
      if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelTwo"))
      {
         InitializeLevels(FMODEvents.instance.levels);
         InitializeAmbience(FMODEvents.instance.ambience);
      }
      
      //deat plays death
      if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Death"))
      {
         InitializeplayerDied(FMODEvents.instance.playerDied);
      }
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
   private void InitializemainMenu(EventReference mainMenuEventReference)
   {
      mainMenuEventInstance = CreateInstance(mainMenuEventReference);
      mainMenuEventInstance.start();
   }
   
   private void InitializeTutorial(EventReference tutorialEventReference)
   {
      tutorialEventInstance = CreateInstance(tutorialEventReference);
      tutorialEventInstance.start();
   }

   private void InitializeLevels(EventReference levelsEventReference)
   {
      levelsEventInstance = CreateInstance(levelsEventReference);
      levelsEventInstance.start();
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
