using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(ConfigurableText))]
public class ConfigurableText : MonoBehaviour
{
    [Tooltip("Defaults to 14")]
    public IntVar fontSize;

    public FloatVar concatenable;
    public string template;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int font = fontSize ? fontSize.Value : 14;
        text.fontSize = font;

        if (concatenable) text.text = template + concatenable.Value;
    }
}
