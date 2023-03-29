using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIBestScore : MonoBehaviour
{
    #region Score

  //  [SerializeField] TextMeshProUGUI bestPlayerName;
   // [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI yourScoreText;

    private void Start()
    {
        ShowBestPlayerScoreUIInfo();
    }
    //public void DisplayBestPlayerName(string _name)
    //{
    //    bestPlayerName.text = _name;
    //}


    public void DisplayScore(int _score)
    {
       // bestScore.text = _score.ToString();
        yourScoreText.text = _score.ToString();
    }
    public void ShowBestPlayerScoreUIInfo()
    {
        if (HighScoreManager.Instance != null)
        {
            HighScoreElement topPlayer = HighScoreHandler.GetTopPlayer();

            if (topPlayer != null)
            {
                HighScoreManager.Instance.bestScorePlayerName = topPlayer.playerName;
                HighScoreManager.Instance.bestScore = topPlayer.score;
             //   DisplayBestPlayerName(HighScoreManager.Instance.bestScorePlayerName);
                DisplayScore(HighScoreManager.Instance.CurrentScore);
            }
            else
            {
             //   DisplayBestPlayerName("");
                DisplayScore(0);
            }

        }
    }
    #endregion
}
