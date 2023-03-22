[System.Serializable]
public class HighScoreElement
{
    public string playerName;
    public int score;

    //constructor:
    public HighScoreElement(string _name, int _score)
    {
        playerName = _name;
        //this.playerName = _name;
        this.score = _score;
    }
}
