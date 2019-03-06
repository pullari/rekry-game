using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : IntEventListener
{
    public IntVar score;

    public override void onEvent(int param)
    {
        score.Value += param;
    }
}
