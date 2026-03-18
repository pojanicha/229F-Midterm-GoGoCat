using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{


    public void OnStartClick()
    { 

        SceneManager.LoadScene("SampleScene");
    }


    public void OnCreditClick()
    {
        SceneManager.LoadScene("Credit");
    }


    public void OnExitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false; // for editor
        Application.Quit();
    }



}
