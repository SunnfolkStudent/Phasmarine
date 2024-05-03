using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineStarter : MonoBehaviour, ITimelineController
{
    public PlayableDirector timeline;

    /*
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "")
        {
            CustomEventManager.instance.onTimelineStart.AddListener(StartTimeline);
        }
    }
    */


    public void StartTimeline()
    {
        timeline.Play();
    }
}