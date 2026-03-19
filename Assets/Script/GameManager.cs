using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static GameManager Instance;

void Awake()
    {
     Instance = this;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Stop the game time
        gameOverUI.SetActive(true);
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnRestartClick()
    {
        Time.timeScale = 1f; // Resume the game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
