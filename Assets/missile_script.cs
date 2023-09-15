using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class missile_script : MonoBehaviour
{

    public GameObject explosion;
    Transform targetEnemy;
    bool missileLock = false;
    public Transform homing;
    public float turn_speed;
    public float speed;
    bool enemyActive = true;
    bool spawn_rotate;

    // Start is called before the first frame update
    void Start()
    {

        //foreach (Laser laser in FindObjectsOfType<Laser>())
        //{
        //    if (laser != this)
        //    {
        //        targetEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        //    }
        //}


        GameObject randomEnemy = FindRandomTarget();

        targetEnemy = randomEnemy.transform;
        spawn_rotate = false;

        Destroy(gameObject, 20);
    }

    GameObject FindRandomTarget()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int rand = Random.Range(0, enemies.Length);
        return enemies[rand];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            if (enemyActive)
            {
                Debug.Log("No enemy on map, return executed.");
                enemyActive = false;
            }

            return;
        }
        if (targetEnemy == null)
        {
            targetEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        if (targetEnemy == null)
        {
            Debug.Log("Could not find enemy.");
            return;
        }


        if (spawn_rotate == false)
        {
            Vector2 direction = targetEnemy.position - transform.position;
            direction.Normalize();
            transform.up = direction;
            spawn_rotate=true;
        }


        Invoke("Missile", 0.5f);

        if (missileLock == true)
        {

            Vector3 vectorToTarget = targetEnemy.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * turn_speed);

        }

    }

    void Missile()
    {
        missileLock = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(newExplosion, 1);
    }


}
