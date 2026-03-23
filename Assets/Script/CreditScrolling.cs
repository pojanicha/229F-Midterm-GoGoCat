using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CreditScrolling : MonoBehaviour
{
    public float scrollSpeed = 70f; // Speed at which the credits scroll

    private RectTransform rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
        // Check if the credits have scrolled past a certain point (e.g., off-screen)

        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            SceneManager.LoadScene("Menu");

        }

    }




}
