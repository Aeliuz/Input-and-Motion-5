using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TitleEffect : MonoBehaviour    
{

    public TextMeshProUGUI title;
    public Image image;
    public Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {
        //title.text = "Stress game";
        //hpBar.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //title.text = Time.time.ToString();
        //title.fontSize = 45 + Mathf.Sin(Time.time * 20) * 5;

    }

    public void PlayButton()
    {
        image.color = Color.red;
    }

}
