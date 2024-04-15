using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    //[SerializeField] private SceneManager _sceneManager;
    
    public GameObject monster;
    public GameObject player;
    private float speed = 0.01f;
    public float distance;
    public bool hidden = false;
    
    void Update()
    {
        monster.transform.position = Vector3.MoveTowards(monster.transform.position, player.transform.position, speed);
        distance = (monster.transform.position - player.transform.position).magnitude;
        if (hidden = false)
        {
            if (distance <= 5 )
            {
                //Claw marks appear?
                Debug.Log("Skummel greie");
            }
            
            else if (distance <= 0.1)
            {
                //_sceneManager.LoadSceneByName("Monster1DeathScene");
            }
        }
        
    }
}
