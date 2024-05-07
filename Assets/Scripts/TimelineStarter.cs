using System.Collections;
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
        print(StatickSceneControler.level);
        timeline.Play();
        if (StatickSceneControler.level == 3)
        {
            StartCoroutine(IGoToEndingScene());
            StatickSceneControler.PuzzleMiniGameDown();
        }
        else
        {
            StartCoroutine(IGoToNextScene());
        }
    }
    private IEnumerator IGoToEndingScene()
    {
        yield return new WaitForSeconds(15f);
        StatickSceneControler.EndingUp();
    }
    private IEnumerator IGoToNextScene()
    {
        yield return new WaitForSeconds(1.5f);
        StatickSceneControler.nextLevel();
    }
}