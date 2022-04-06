using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ReturnMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOverScene(){
        SceneManager.LoadScene("GameOver");
    }

    public void StartGame(){
        SceneManager.LoadScene("Murder1");
    }

    public void NextLevel(int index){
        SceneManager.LoadScene(index);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
