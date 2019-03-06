using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DeactivateOutsideScreen : MonoBehaviour
{
    bool wasOnScreen;

    void OnBecameVisible()
    {
        wasOnScreen = true;
    }

    void OnBecameInvisible()
    {
        if (wasOnScreen) gameObject.SetActive(false);
        wasOnScreen = false;
    }

}
