using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Score : MonoBehaviour
{
    public string playerName;
    public int score;
    public Color color;
    //constructor:
    public Score(Color _color, string _name, int _score)
    {
        this.color = _color;
        this.playerName = _name;
        this.score = _score;
    }
}
