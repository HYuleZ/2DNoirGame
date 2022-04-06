using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueControl1 : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Text speechText;
    public Text actorNameText;
    public bool isDetective;
    public Timer timerControl;
    public bool isPolicial;
    public bool bolName;
    public string detectiveName;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;
    private PlayerController pc;

    void Start(){
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if(isPolicial && index > 1 && bolName){
            actorNameText.text = detectiveName;
            actorNameText.color = Color.yellow;
        }
    }

    public void Speech(string[] txt, string actorName){
        dialogueObj.SetActive(true);
        sentences = txt;
        actorNameText.text = actorName;
        pc.animator.SetFloat("Run", 0);
        pc.enabled = false;
        timerControl.isRunning = false;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence(){
        foreach(char letter in sentences[index].ToCharArray()){
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        if(speechText.text == sentences[index]){
            if(index < sentences.Length - 1){
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }else{
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                pc.enabled = true;
                if(isDetective){
                    timerControl.isRunning = true;
                }
            }
        }
    }
}
