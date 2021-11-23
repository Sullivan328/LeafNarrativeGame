using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LeafGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startScreen;
    [SerializeField]
    private GameObject dialogueScreen;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;
    [SerializeField]
    private GameObject pausemenu;

    [SerializeField]
    private GameObject pausemenu2;

    public static bool GameIsPaused = false;

  

    [HideInInspector]
    public bool gameHasStarted = false;

   

    // Start is called before the first frame update
    private IEnumerator StartGameOP()
    {
        yield return new WaitForEndOfFrame();
        startScreen.SetActive(false);
        Resume();
    }

    public void StartGame()
    {
        StartCoroutine(StartGameOP());
        
    }

    // Update is called once per frame
    private void GoToStartScreen()
    {
        startScreen.SetActive(true);
    }

    private void openPauseMenu()
    {
        if(GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void winGame()
    {
        winScreen.SetActive(true);
    }

    public void loseGame()
    {
        loseScreen.SetActive(true);
    }
    public void Resume()
    {
        pausemenu.SetActive(false);
        pausemenu2.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Pause2()
    {
        pausemenu2.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void DialogueScreen()
    {
        dialogueScreen.SetActive(true);
       
    }




    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
      
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
