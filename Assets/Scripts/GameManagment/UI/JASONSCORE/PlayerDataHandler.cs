using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class PlayerDataHandler : MonoBehaviour
{
    public static string currentPlayerName;
    public static Color currentPlayerColor;
    public static int _currentScore;

    public static List<PlayerDataElement> playersEntriesList = new List<PlayerDataElement>();
    public static List<PlayerDataElement> playersListInOrder = new List<PlayerDataElement>();

    static string filename = "dontLitterHerePlayersEntries.json";

    /* C:/Users/Olesia/AppData/LocalLow/olesiaZaidman/Don't Litter Here!/dontLitterHerePlayersEntries.json*/

    static int maxLeaderboardEntries = 5;
  
    public static int CurrentScore //used to be moneyScore
    {
        get { return _currentScore; }
        set { _currentScore = value; }
    }

    void Start()
    {
        LoadData();
        SortList();
    }

    #region PlayerName
    public static void CurentPlayerNameSelected(string _name)
    {
        Debug.Log("currentPlayerName:"+ _name);
        currentPlayerName = _name;
    }
    #endregion

    #region PlayerColor
    public static void CurentPlayerColorSelected(Color _color)
    {
        currentPlayerColor = _color;
    }
    #endregion

    static void SaveData()
    {
        Debug.Log("SaveData in PlayerDataHandler");
        FileHandler.SaveToJSON<PlayerDataElement>(playersEntriesList, filename);
    }

    static void LoadData()
    {
        playersEntriesList = FileHandler.ReadListFromJSON<PlayerDataElement>(filename);

        while (playersEntriesList.Count > maxLeaderboardEntries)
        {
            playersEntriesList.RemoveAt(maxLeaderboardEntries);
        }
    }

    public static void SaveDataEntryToTheList()
    {
       playersEntriesList.Add(new PlayerDataElement(currentPlayerName, CurrentScore));
       SortList();

        // playersEntriesList.Sort(PlayerDataHandler.sorter);

        // playersEntriesList.Sort();

        /*  public void Sort(int index, int count, IComparer<T> comparer);
        public void Sort();
        public void Sort(IComparer<T> comparer);*/

       Debug.Log("Current entry Added to the list. PlayerName: " + currentPlayerName + " CurrentScore: " + CurrentScore);
       SaveData();
    }

    public static void SortList()
    {
        playersListInOrder = playersEntriesList.OrderByDescending(x => x.score).ToList();
        Debug.Log("List is sorted. playersListInOrder[0]:" + "  Name" + playersListInOrder[0].playerName + "  Score" + playersListInOrder[0].score+ "  Name"+ playersListInOrder[1].playerName + "  playersListInOrder[1]:" + playersListInOrder[1].score);
    }
    public static void AddHighScoreIfPossiable(PlayerDataElement element)
    {
        //for (int i = 0; i < maxLeaderboardEntries; i++)
        //{
        //    if (i >= playersEntriesList.Count || element.score > playersEntriesList[i].score)
        //    {
        //        //add new high score:
        //        playersEntriesList.Insert(i, element);

        //        while (playersEntriesList.Count > maxLeaderboardEntries)
        //        {
        //            playersEntriesList.RemoveAt(maxLeaderboardEntries);
        //        }

        //        SaveData();
        //        Debug.Log("AddHighScoreIfPossiable: currentPlayerName" + currentPlayerName + "CurrentScore: " + CurrentScore);

        //        break;
        //    }
      //  }
    }
}
