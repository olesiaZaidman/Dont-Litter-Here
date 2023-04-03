[System.Serializable]

public class PlayerDataElement //: IComparable
{
    public string playerName;
    public int score;

    //constructor:
    public PlayerDataElement(string _name, int _score)
    {
        this.playerName = _name;
        this.score = _score;
    }

}
