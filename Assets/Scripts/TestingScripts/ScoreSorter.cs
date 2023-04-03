using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSorter : IComparer<PlayerDataElement>
{
    public int Compare(PlayerDataElement element_01, PlayerDataElement element_02)
    {
        if (element_01.score > element_02.score)
        {
            return 1;
        }

       else if (element_01.score < element_02.score)
        {
            return -1;
        }

        else if (element_01.score == element_02.score)
        {
            return 0;
        }

        else
            return element_01.score.CompareTo(element_02.score);

    }
}
