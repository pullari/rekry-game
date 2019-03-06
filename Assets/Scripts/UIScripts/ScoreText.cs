using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    public IntVar score;

    Text textField;

    void Start()
    {
        textField = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(textField && score) textField.text = "Score: " + score.Value.ToString();
    }
}
