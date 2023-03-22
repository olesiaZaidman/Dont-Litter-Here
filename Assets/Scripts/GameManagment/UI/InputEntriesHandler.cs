using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEntriesHandler : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] InputEntry input;
    static string filename = "randomPlayerScores.json";
    static List<InputEntry> entries = new List<InputEntry>();

    void Start()
    {
        LoadData();
    }

    public static void AddEntryToTheList()
    {
        entries.Add(new InputEntry(HighScoreManager.currentPlayerName, HighScoreManager.Instance.CurrentScore));
        SaveData();
    }

    static void SaveData()
    {
        FileHandler.SaveToJSON<InputEntry>(entries, filename);
    }

    static void LoadData()
    {
        entries = FileHandler.ReadListFromJSON<InputEntry>(filename);
    }
}
