using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class ConfigurableRectTransform : MonoBehaviour
{
    [Tooltip("Defaults to full canvas")]
    public Vector2Var size;
    RectTransform rt;

    public bool scaleAccordingToScreenSize = true;
    [Tooltip("This is used to scale the ui elements to the screen size")]
    public float defaultScreenSizeX = 1920;
    public float defaultScreenSizeY = 1080;

    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (size == null)
        {
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
        }
        else
        {
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.Value.x);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.Value.y);

            if (scaleAccordingToScreenSize)
            {
                rt.localScale = new Vector3(Screen.width / defaultScreenSizeX, Screen.height / defaultScreenSizeY, 1);
            }
        }
    }
}
