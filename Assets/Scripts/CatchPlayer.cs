using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag.Equals("Player")){
            FindObjectOfType<MenuManager>().GameOverScene();
            Debug.Log("Achei o player");
        }
    }
}
