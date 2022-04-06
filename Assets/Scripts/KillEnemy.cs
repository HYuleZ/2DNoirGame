using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject buttonSprite;
    public EnemyPatroll enemyGO;
    public bool isTargetLevel;

    GameObject playerTarget;
    public bool canKillEnemy = false;

    void Start() {
        buttonSprite.SetActive(false);
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        if(enemyGO.isTargetLevel == true){
            isTargetLevel = true;
        }
    }

    void Update() {
        CanKillEnemy(canKillEnemy);
    }

    public void CanKillEnemy(bool canKill){
        if(canKill){
            if(Input.GetKeyDown(KeyCode.K)){
                Debug.Log("Matou");
                enemyGO.KillEnemy(true, isTargetLevel);
            }
        }
    }

    public void ButtonCanKillEnter(bool onOff){
        buttonSprite.SetActive(onOff);
        canKillEnemy = onOff;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == playerTarget){
            ButtonCanKillEnter(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject == playerTarget){
            ButtonCanKillEnter(false);
        }
    }
}
