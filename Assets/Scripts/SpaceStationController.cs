using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationController : MonoBehaviour
{
    public Vector3Event fireEvent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Plane clickDetectionPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0;

            if (clickDetectionPlane.Raycast(ray, out enter))
            {
                if (fireEvent != null) fireEvent.RaiseEvent(ray.GetPoint(enter));
            } 
        }
    }
}
