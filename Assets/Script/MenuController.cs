using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{


    public void OnStartClick()
    { 

        SceneManager.LoadScene("GamePlay");
    }


    public void OnCreditClick()
    {
        SceneManager.LoadScene("Credit");
    }


    public void OnExitClick()
    {
        /*UnityEditor.EditorApplication.isPlaying = false; // for editor
        Application.Quit();*/

        #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }



}
