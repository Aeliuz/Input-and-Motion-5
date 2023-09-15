using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    Transform target;
    Rigidbody2D rb2D;

    public float speed = 3;
    public int Health = 3;
    public GameObject enemy;
    public GameObject Apple;
    Vector2 CurrPos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb2D.velocity = direction * speed;
        transform.up = direction;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<missile_script>() != null)
        {

            if (Health > 0)
            {
                Health--;
                return;
            }

            Health = 3;
            float x = Random.Range(20, 10);
            float y = Random.Range(16, 8);



            Vector3 randomPosition = Random.insideUnitCircle * 20;
                        

            while (randomPosition.sqrMagnitude < 10 * 10)
            {
                randomPosition = Random.insideUnitCircle * 30;
            }

            Instantiate(enemy, player.transform.position + randomPosition, transform.rotation);


            Vector3 randomPosition2 = Random.insideUnitCircle * 20;
            Vector2.Distance(transform.position, player.transform.position);


            while (randomPosition.sqrMagnitude < 10 * 10)
            {
                randomPosition = Random.insideUnitCircle * 30;
            }


            int check = Random.Range(1, 8);


            if(check < 9) 
            {
                Instantiate(Apple, transform.position, Quaternion.identity);
            }
            if(check == 7) 
            {
                Instantiate(enemy, player.transform.position + randomPosition2, transform.rotation);
            }

            Invoke("Death", 0.1f);
        }
    }

    private void Death()
    {
        Destroy(gameObject); 
    }

}
