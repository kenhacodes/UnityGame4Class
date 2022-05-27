using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string juego;

    public void StartGame(){
        StartCoroutine(WaitForPlay());
    }

    public void OpenOptions(){

    }

    public void CloseOptions(){

    }

    public void QuitGame(){
        Application.Quit();
    }

    private IEnumerator WaitForPlay()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(juego);
    }
}
