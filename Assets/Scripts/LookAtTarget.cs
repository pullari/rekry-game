using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [Tooltip("Target that the transform should look at. Defaults to MainCamera")]
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null) target = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
    }
}
