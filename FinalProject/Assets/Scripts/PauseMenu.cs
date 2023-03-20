using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pauseMenu;
    private bool isPause;
    private GameObject pauseButton;
    // Update is called once per frame
    private void Start()
    {
        pauseMenu.SetActive(false);
        pauseButton = GameObject.FindGameObjectWithTag("PauseButton");
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPause)
                resumeGame();
            else
            {
                pauseGame();
            }
        }
    }
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        pauseButton.SetActive(false);
    }
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
        pauseButton.SetActive(true);
    }
    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    
}
