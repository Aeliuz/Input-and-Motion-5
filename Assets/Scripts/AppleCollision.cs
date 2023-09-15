using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollision : MonoBehaviour
{
    //public PlayerFire Player;
  
    // Start is called before the first frame update
    void Start()
    {
        //points = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player.points++;
        Score.Instance.AddPoints();
        Destroy(gameObject);
    }

}
