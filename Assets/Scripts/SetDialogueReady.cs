using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogueReady : MonoBehaviour
{

    public Dialogue dialogue;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetReady(){
        dialogue.ready = true;
    }
    public void SetNotReady(){
        dialogue.ready = false;
    }
}
