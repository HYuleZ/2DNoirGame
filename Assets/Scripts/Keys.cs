using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public int scoreKeys;
    public GameObject[] keysVetor;
    int maxScoreKeys;
    public GameObject canKill;
    // public GameObject canvasWin;
    public GameObject buttonNext;
    public KillEnemy killEnemy;
    public bool isEnemy;
    public Text currentScoreText;
    public Text maxScoreText;
    [SerializeField] bool canKillBool;

    void Start()
    {
        maxScoreKeys = keysVetor.Length;
        scoreKeys = 0;
        canKill.SetActive(false);
        canKillBool = false;
        buttonNext.SetActive(false);

        if(!isEnemy){
            currentScoreText.GetComponent<Text>().text = scoreKeys.ToString();
            maxScoreText.GetComponent<Text>().text = maxScoreKeys.ToString();
        }
    }

    void Update()
    {
        if(!isEnemy){
            CanKill();
        }

        if(canKillBool && Input.GetKeyDown(KeyCode.K)){
            Debug.Log("Fim de fase!");
            buttonNext.SetActive(true);
        }
    }

    void CanKill(){
        if(scoreKeys >= maxScoreKeys){
            Debug.Log("Can Kill");
            canKill.SetActive(true);
            scoreKeys = 0;
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag.Equals("Key")){
            scoreKeys++;
            currentScoreText.GetComponent<Text>().text = scoreKeys.ToString();
            Destroy(col.gameObject);
        }
        if(col.gameObject == canKill){
            canKillBool = true;
            if(!isEnemy){
                killEnemy.ButtonCanKillEnter(true);
            }   
        }
    }

    private void OnTriggerExit(Collider other) {
        canKillBool = false;
        if(!isEnemy){
            killEnemy.ButtonCanKillEnter(false);
        }
    }
}
