using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEntriesHandler : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] InputEntry inputField;
   // static string filename = "dontLitterHereInputEntriesPlayers.json";
 //   static List<InputEntry> entries = new List<InputEntry>();

    void Start()
    {
   //     LoadData();
    }

    //public static void AddEntryToTheList()
    //{
    //  //  entries.Add(new InputEntry(PlayerDataHandler.currentPlayerName, PlayerDataHandler.CurrentScore));
    //   // SaveData();
    //}

    //static void SaveData()
    //{
    //    Debug.Log("SaveData in InputEntriesHandler");
    //    FileHandler.SaveToJSON<InputEntry>(entries, filename);
    //}

    //static void LoadData()
    //{
    //    entries = FileHandler.ReadListFromJSON<InputEntry>(filename);
    //}
}
