using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuObeject;
    public GameObject optionsMenuObeject;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsMenuActive()
    {
        mainMenuObeject.SetActive(false);
        optionsMenuObeject.SetActive(true);
        
    }

    public void BackButton()
    {
        optionsMenuObeject.SetActive(false);
        mainMenuObeject.SetActive(true);
        
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("HAS EXIT");
    }
}
