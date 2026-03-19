using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float timeScale; // Put the number in the Unity Inspector (Put as Second ex. 2 mins == 120 sec)
    public GameManager gameManager;
    bool isGameOver = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f; // Ensure the game time is running at normal speed
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return; // Exit the Update method if the game is already over
        

        if (timeScale > 0)
        {
            timeScale -= Time.deltaTime;
        }

        else
        {
            timeScale = 0;
            isGameOver = true; // Set the flag to indicate the game is over

            gameManager.GameOver();

        }

        int minutes = Mathf.FloorToInt(timeScale / 60);
        int seconds = Mathf.FloorToInt(timeScale % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }
}
