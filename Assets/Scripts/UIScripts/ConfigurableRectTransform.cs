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
        }
    }
}
