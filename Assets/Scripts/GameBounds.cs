using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBounds : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
