using UnityEngine;
using UnityEngine.Playables;


public class TimelineStarter : MonoBehaviour, ITimelineController
{
    private PlayableDirector timeline;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    public void StartTimeline()
    {
        print("playing timline");
        timeline.Play();
    }
}