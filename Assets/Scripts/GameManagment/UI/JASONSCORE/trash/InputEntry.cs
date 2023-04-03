[System.Serializable]
public class InputEntry
{
    //make sure class is Serializable
    //and variables are public
    public string playerName;
    public int score;

    //constructor:
    public InputEntry(string _name, int _score)
    {
        this.playerName = _name;
        this.score = _score;
    }
}
