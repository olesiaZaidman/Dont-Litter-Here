using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
 //   // [SerializeField] [Range(0f, 5f)] float sceneLoadDelay;
 //   [SerializeField] TextMeshProUGUI startButtonText;
 //   AudioManagerBase audioManager;
 //   PlayerBase player;

 //   Color yellowColor = new Color(1f, 0.8509804f, 0f, 1f); //FFD900 yellow
 ////   bool isClicked = false;
 //   [Header("Effects")]
 //   [SerializeField]  GameObject lights;
 //   [SerializeField] GameObject playerLight;
 //   [SerializeField] GameObject signsLight;
 //   [Header("Submenu Canvases")]
 //   [SerializeField]  GameObject submenuPanelCanvas;
 //   [SerializeField]  GameObject submenuDataPersistence;


 //   private void Awake()
 //   {
 //       audioManager = FindObjectOfType<AudioManagerBase>();
 //       player = FindObjectOfType<PlayerBase>();
 //   }

 //   void Start()
 //   {
 //     //  isClicked = false;
 //       if (startButtonText != null)
 //       { startButtonText.color = Color.white; }
 //   }
   

 //   public void LoadMainMenu()
 //   {
 //       audioManager.PlayClickSound();
 //       SceneManager.LoadScene("MainMenu"); //by name
 //   }

 //   public void LoadFinalScore()
 //   {
 //       float _sceneLoadDelay = 3.5f;
 //       audioManager.PlayClickSound();
 //       StartCoroutine(WaitAndLoad("FinalScore", _sceneLoadDelay));
 //   }

 //   //public void ReloadGame()
 //   //{
 //   //    SceneManager.LoadScene("Game"); //by name
 //   //}

 //   //public void QuitGame()
 //   //{
 //   //    audioManager.PlayClickSound();
 //   //    Application.Quit();
 //   //}

 //   IEnumerator WaitAndLoad(string _sceneName, float _delay)
 //   {
 //       yield return new WaitForSeconds(_delay);

 //       SceneManager.LoadScene(_sceneName);
 //   }



   
}
