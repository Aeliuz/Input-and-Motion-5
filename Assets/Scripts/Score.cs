using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TextMeshProUGUI Scoreboard;
    public int Points;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scoreboard.text = "Score: " + Points.ToString();
    }
    public void AddPoints()
    {
        Points++;
        Debug.Log(Points);
    }
}
