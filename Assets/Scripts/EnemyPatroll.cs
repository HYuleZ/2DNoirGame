using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroll : MonoBehaviour
{
    [SerializeField] int contWait;
    [SerializeField] int maxContWait;

    public Transform[] waypoints;
    public int speedEnemy;
    public Animator animator;
    public bool isTargetLevel;
    public bool isDead;
    public bool isDetective;
    public bool showAnimationFinale;
    public GameObject imageWin;
    public GameObject nextLevelButton;
    public GameObject redCanvasKill;
    public Animator redCanvasAnimator;
    public Animator lightMurderAnimation;

    private int waypointIndex;
    private float dist;

    void Start(){
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(dist < 1f){
            AumentarCont();
        }else{
            Patrol();
        }
    }

    void Patrol(){
        transform.Translate(Vector3.forward * speedEnemy * Time.deltaTime);
        animator.SetFloat("Run", 2);
    }

    void IncreaseIndex(){
        contWait = 0;
        waypointIndex++;
        if(waypointIndex >= waypoints.Length){
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void AumentarCont(){
        contWait++;
        animator.SetFloat("Run", -1);
        if(contWait >= maxContWait){
            IncreaseIndex();
        }
    }

    public void Dead(bool dead){
        if(dead){
            this.gameObject.SetActive(false);
        }
    }

    public void KillTargetLevel(bool dead, bool lastTarget){
        if(dead && lastTarget && !isDetective){
            WinCanvasButton(true);
        }else if(dead && lastTarget && isDetective){
            lightMurderAnimation.SetInteger("MurderShow", 1);
            showAnimationFinale = true;
        }
    }

    public void WinCanvasButton(bool onOff){
        imageWin.SetActive(onOff);
        nextLevelButton.SetActive(onOff);
    }

    public void KillEnemy(bool dead, bool lastTarget){
        isDead = dead;
        if(!isDetective){
            redCanvasKill.SetActive(true);
            redCanvasAnimator.SetBool("KillRed", true);
            Invoke("SetAnimationBool", 1f);
        }
        if(dead){
            Dead(dead);
            if(lastTarget){
                KillTargetLevel(dead, lastTarget);
            }
        }
    }

    public void SetAnimationBool(){
        redCanvasAnimator.SetBool("KillRed", false);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Encostou no player");
            FindObjectOfType<MenuManager>().GameOverScene();
        }
    }
}
