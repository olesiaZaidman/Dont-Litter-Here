using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float sceneLoadDelay;

    public void LoadGame()
    {
        if (ScoreManager.Instance != null)
        { 
            ScoreManager.Instance.ResetMoneyScore(); 
        }
        SceneManager.LoadScene("Game"); //by name
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //by name
    }

    public void LoadFinalScore()
    {
        StartCoroutine(WaitAndLoad("FinalScore", sceneLoadDelay));
    }

    //public void ReloadGame()
    //{
    //    SceneManager.LoadScene("Game"); //by name
    //}

    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator WaitAndLoad(string _sceneName, float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_sceneName);
    }
}
