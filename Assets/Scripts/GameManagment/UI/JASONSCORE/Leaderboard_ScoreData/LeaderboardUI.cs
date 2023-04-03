using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    public GridRowsUi rowUI;

    void Start()
    {
        CreateNewRowOfPlayerScoreRating();
    }

    void CreateNewRowOfPlayerScoreRating()
    {
        var scores = PlayerDataHandler.playersEntriesList.ToArray();

        int numberOfResults = Mathf.Clamp(scores.Length, 0, 5); //max we can have 5

        for (int i = 0; i < numberOfResults; i++)  // for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<GridRowsUi>();

            int rank = i + 1;
            string rankString;

            switch (rank)
            {
                case 1:
                    rankString = "1st";
                    break;
                case 2:
                    rankString = "2nd";
                    break;
                case 3:
                    rankString = "3rd";
                    break;
                default:
                    rankString = rank.ToString() + "th";
                    break;
            }

            row.rankText.text = rankString;            
            row.nameText.text = scores[i].playerName; 
            row.scoreText.text = scores[i].score.ToString();    
        }
    }
}
