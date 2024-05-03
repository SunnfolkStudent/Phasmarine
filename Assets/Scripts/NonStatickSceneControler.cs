using System.Collections;
using UnityEngine;
using UnityEngine.Playables;


public class NonStatickSceneControler : MonoBehaviour
{
    [SerializeField] private PlayableDirector timline;
    public void StartGame()
    {
        StartCoroutine(IStartGame());
        timline.Play();
    }
    public void Creedits()
    {
        StartCoroutine(ICreedits());
        timline.Play();
    }
    public void TryAgain()
    {
        StartCoroutine(ITryAgain());
        timline.Play();
    }
    public void ReturnToMenue()
    {
        StartCoroutine(IReturnToMenue());
        timline.Play();
    }
    public void ReturnToMenueWhitouteFade()
    {
        StatickSceneControler.MainMenu();
    }
    public void Exit()
    {
        Application.Quit();
    }
    
    
    public IEnumerator IStartGame()
    {
        yield return new WaitForSeconds(1.5f);
        StatickSceneControler.StartGame();
    }
    public IEnumerator ICreedits()
    {
        yield return new WaitForSeconds(1.5f);
    }
    public IEnumerator ITryAgain()
    {
        yield return new WaitForSeconds(1.5f);
        StatickSceneControler.TryAgain();
    }
    public IEnumerator IReturnToMenue()
    {
        yield return new WaitForSeconds(1.5f);
        StatickSceneControler.MainMenu();
    }
}
