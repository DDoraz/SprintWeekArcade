using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleText : MonoBehaviour
{
    private TextMeshPro coinText;
    public Color lerpColor;
    // Start is called before the first frame update
    void Awake()
    {
        TextMeshPro coinText = GetComponent<TextMeshPro>();
        Color lerpColor = new Color();
        coinText.color = lerpColor;
    }

    // Update is called once per frame
    void Update()
    {
        lerpColor = Color.Lerp(Color.yellow, Color.white, Mathf.PingPong(Time.time, 1));
    }
}
