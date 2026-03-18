using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float timeScale; // Put the number in the Unity Inspector (Put as Second ex. 2 mins == 120 sec)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeScale > 0)
        {
            timeScale -= Time.deltaTime;
        }

        else
        {
            timeScale = 0;

        }

        int minutes = Mathf.FloorToInt(timeScale / 60);
        int seconds = Mathf.FloorToInt(timeScale % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }
}
