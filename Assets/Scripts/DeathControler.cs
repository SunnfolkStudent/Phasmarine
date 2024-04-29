using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathControler : MonoBehaviour
{
    public static int level = 1;

    public void Revive()
    {
        if (level == 1)
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (level == 2)
        {
            SceneManager.LoadScene("LevelOne");
        }
        if (level == 3)
        {
            SceneManager.LoadScene("Leveltwo");
        }
    }
}
