using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fixingventsminigame : MonoBehaviour
{
    
    public string sceneName;
    public Sprite[] puzzleSprites;
    public Image[] puzzleImages;
    public string currentResult;
    public string finalResult;

    public GameObject puzzleMaster;

    public void OnPuzzleClick()
    {
        var currentImage = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;

        for (int i = 0; i < puzzleSprites.Length; i++)
        {
            if (currentImage == puzzleSprites[i])
            {
                if (i+1 >= puzzleSprites.Length)
                {
                    EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = puzzleSprites[0];
                }
                else
                {
                    EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = puzzleSprites[i+1];
                }
            }
        }
        OnPuzzleCheck();
    }

    public void OnPuzzleCheck()
    {
        currentResult = null;
        foreach (var image in puzzleImages)
        {
            for (int i = 0; i < puzzleSprites.Length; i++)
            {
                if (image.sprite == puzzleSprites[i])
                {
                    currentResult += i.ToString();
                }
            }
        }


        if (currentResult == finalResult)
        {
            print("Success");
            PlayerPrefs.SetInt("BookShelf",PlayerPrefs.GetInt("BookShelf") + 1);
            puzzleMaster.SetActive(false);
            //SceneManager.LoadScene(sceneName);
        }
        else
        {
            print("Not success");
        }
    }
    
    
}
