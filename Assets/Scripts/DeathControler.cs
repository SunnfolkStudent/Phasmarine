using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathControler : MonoBehaviour
{

    public void Revive()
    {
        if (StatickSceneControler.level == 1)
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (StatickSceneControler.level == 2)
        {
            SceneManager.LoadScene("LevelOne");
        }
        if (StatickSceneControler.level == 3)
        {
            SceneManager.LoadScene("Leveltwo");
        }
    }
}
