using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{
    public bool Occupied = false;
    [SerializeField] private int TileID;
    public bool IsCorrect = false;
    
    public void Check(int id)
    {
        Occupied = true;
        Debug.Log("Checked");
        Debug.Log(TileID);
        Debug.Log(id);
        if (TileID == id)
        {
            IsCorrect = true;
            print("Correct");
        }
    }
}
