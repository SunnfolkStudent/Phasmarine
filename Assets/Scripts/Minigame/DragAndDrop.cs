using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private MiniGameManager _miniGameManager;
    private int seaweedleft = 7;

    void Start()
    {
        _miniGameManager = GetComponent<MiniGameManager>();
    }
    
    
    
    
    
    
    
    
    
    void OnTriggerExit(Collider other)
    {
        seaweedleft -= 1;
        if (seaweedleft == 0)
        {
            _miniGameManager.CleaningMiniGameDown();
        }
        //Destroy(other.gameObject);
    }
}
