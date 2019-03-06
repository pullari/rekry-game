using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator[] animatedCanvases;

    int current = 0;

    void Start()
    {
        animatedCanvases[current].SetBool("isOpen", true);
    }

    public void Show(int index)
    {
        if (index < 0 || index >= animatedCanvases.Length) return;

        animatedCanvases[current].SetBool("isOpen", false);
        animatedCanvases[index].SetBool("isOpen", true);
        current = index;
    }
}
