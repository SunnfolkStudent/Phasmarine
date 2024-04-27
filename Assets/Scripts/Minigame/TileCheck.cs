using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{
    [SerializeField] private int TileID;
    public bool IsCorrect = false;
    
    public void Check(int id)
    {
        print("Checked");
        if (TileID == id)
        {
            IsCorrect = true;
            print("Correct");
        }
    }
}
