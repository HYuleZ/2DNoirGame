using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerController playerController;

    void Awake(){
        playerController = GetComponentInParent<PlayerController>();
    }

//Trigger-------------------
    void OnTriggerEnter(Collider other){
        if(other.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundedState(true);
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundedState(false);
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundedState(true);
    }
//--------------------Trigger


//Collision-------------------------
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundedState(true);
    }
    void OnCollisionExit(Collision collision){
        if(collision.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundedState(false);
    }
    void OnCollisionStay(Collision collision){
        if(collision.gameObject == playerController.gameObject)
            return;

        playerController.SetGroundedState(true);
    }
//------------------------------------Collision
}
