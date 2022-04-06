using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Header("Detective")]
    public string[] speechTxt;
    public string actorName;

    [Header("Murder")]
    public string[] murderSpeechText;
    public string murderName;

    [Header("Canvas")]
    public GameObject newsPaperReadyDialogue;
    public GameObject dialogueCanvas;

    public LayerMask playerLayer;
    private DialogueControl1 dc;
    public bool ready;
    public EnemyPatroll finalEnemy;
    void Start()
    {
        dc = FindObjectOfType<DialogueControl1>();
        ready = false;
        dialogueCanvas.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if(ready){
            dialogueCanvas.GetComponent<Canvas>().enabled = true;
            dc.Speech(speechTxt, actorName);
            //Debug.Log("HA");
            ready = false;
        }

        if(dialogueCanvas.activeSelf && finalEnemy.isDetective && finalEnemy.showAnimationFinale){
            dc.actorNameText.GetComponent<Text>().color = Color.red;
            StartCoroutine(WaitFunction(1f));
            finalEnemy.showAnimationFinale = false;
        }
    }

    IEnumerator WaitFunction(float sec){
        yield return new WaitForSeconds(sec);
        dc.Speech(murderSpeechText, murderName);
    }
}
