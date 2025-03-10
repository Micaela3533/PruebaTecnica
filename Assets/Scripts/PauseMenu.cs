using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    private bool isPaused = false; 

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);  
        Time.timeScale = 0f;   
        isPaused = true;  
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);      
        Time.timeScale = 1f;             
        isPaused = false;    
    }

    public void QuitGame()
    {

        SceneManager.LoadScene("MenuScene");
    }
}
