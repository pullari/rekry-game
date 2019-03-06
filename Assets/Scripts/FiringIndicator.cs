using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringIndicator : Vector3Listener
{
    public GameObject indicator;

    public override void onEvent(Vector3 param)
    {
        Instantiate(indicator, param, Quaternion.identity);
    }
}
