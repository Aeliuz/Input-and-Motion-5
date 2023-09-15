using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject LaserPrefab;
    public Score player_score;
    float fireRate = 0.5f;
    public int points = 0;
    public Transform gun1;
    public Transform gun2;
    float timer;
    int counter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        transform.up = direction;
        //int score = player_score.Points;
        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            //score = score - 5;
            counter++;
            if (counter % 2 == 0)
            {
                Instantiate(LaserPrefab, gun1.position, transform.rotation);
            }
            else
            {
                Instantiate(LaserPrefab, gun2.position, transform.rotation);
            }
            
            timer = 0;
        }

        timer += Time.deltaTime;

    }
}
