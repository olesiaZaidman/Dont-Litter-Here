using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIBestScore : MonoBehaviour
{
    #region Score

 
    [SerializeField] TextMeshProUGUI yourScoreText;

    void Start()
    {
        // ShowBestPlayerScoreUIInfo();
        ShowYourScoreUIInfo();
    }
    public void DisplayScore(int _score)
    {
        if (yourScoreText != null)
        {
            yourScoreText.text = _score.ToString();
        }
        else Debug.Log("yourScoreText is null");
    }
    public void ShowYourScoreUIInfo()
    {
        Debug.Log("UIBestScore - ShowYourScoreUIInfo");
     //   if (PlayerDataHandler.Instance != null)
       // {
            DisplayScore(PlayerDataHandler.CurrentScore);
            Debug.Log("UIBestScore - ShowYourScoreUIInfo - DisplayScore: " + PlayerDataHandler.CurrentScore);
       // }
        //else
        //{
        //    Debug.Log("No PlayerDataHandler Instance");

        //    DisplayScore(0);
        //}
    }

    //public void ShowBestPlayerScoreUIInfo()
    //{
    //    if (HighScoreManager.Instance != null)
    //    {
    //        HighScoreElement topPlayer = HighScoreHandler.GetTopPlayer();

    //        if (topPlayer != null)
    //        {
    //            HighScoreManager.Instance.bestScorePlayerName = topPlayer.playerName;
    //            HighScoreManager.Instance.bestScore = topPlayer.score;
    //            //   DisplayBestPlayerName(HighScoreManager.Instance.bestScorePlayerName);
    //            ShowYourScoreUIInfo();
    //        }
    //        else
    //        {
    //            //   DisplayBestPlayerName("");
    //            DisplayScore(0);
    //        }

    //    }
    //}

    //  [SerializeField] TextMeshProUGUI bestPlayerName;
    // [SerializeField] TextMeshProUGUI bestScoreText;
    //public void DisplayBestPlayerName(string _name)
    //{
    //    bestPlayerName.text = _name;
    //}

    //public void DisplayBestScore(int _score)
    //{
    //  bestScore.text = _score.ToString();

    //}
    #endregion
}
