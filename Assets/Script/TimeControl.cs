using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float timeScale; // Put the number in the Unity Inspector (Put as Second ex. 2 mins == 120 sec)
    public GameManager gameManager;
    bool isGameOver = false;

    public static TimeControl Instance; // for call this script easily ja

    private void Awake()
    {
        Instance = this;
    }

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

    public void ReduceTime(float amount) // Reduce time (use in obstacle scripts)
    {
        timeScale -= amount;

        StartCoroutine(ChancgeColorRed());
    }

    IEnumerator ChancgeColorRed() // use this to specify the color change duration.
    {
        timeText.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        timeText.color = Color.white;
    }

    public void AddTime(float amount)
    {
        timeScale += amount;

        StartCoroutine(ChancgeColorGreen());
        
    }

    IEnumerator ChancgeColorGreen()
    {
        timeText.color = Color.green;

        yield return new WaitForSeconds(0.5f);

        timeText.color = Color.white;
    }

}
