using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : IntEventListener
{
    public IntVar score;

    new void Start()
    {
        base.Start();
        score.Value = 0;
    }

    public override void onEvent(int param)
    {
        score.Value += param;
    }
}
