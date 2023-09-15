using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class Laser : MonoBehaviour
{

    public GameObject explosion;
    Transform targetEnemy;
    bool missileLock = false;
    public Transform homing;
    public float speed;
    public GameObject dot;
    int i = 0;
    bool enemyActive = true;

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
        transform.position += transform.up * 10 * Time.deltaTime;

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
            i++;
            if (i > 5)
            {
                Debug.Log("Could not find enemy.");
                return;
            }
        }
        if (targetEnemy == null)
        {
            Debug.Log("Could not find enemy.");
            return;
        }


        
        
        Invoke("Missile", 0.5f);

        if (missileLock == true)
        {
            //Vector2 currDir = transform.up;
            //currDir.Normalize();
            //Vector2 EnemyPos = targetEnemy.position;
            //EnemyPos.Normalize();
            //dot.transform.position = new Vector2(transform.position.x, transform.localPosition.y + 1);

            //Vector2 currDir = dot.transform.position.normalized;


            //Vector2 heading = dot.transform.position - transform.position;
            //Vector2 direction = targetEnemy.transform.position - transform.position;
            //Vector2 turn = transform.Rotate();
            //transform.up = Vector2.Lerp(transform.position, targetEnemy.position, 1f);


            //if (targetEnemy.position.x < transform.position.x)
            //{
            //    Vector3 rotation = new Vector3(1, 0, 0);
            //    transform.Rotate(rotation);
            //}
            //if (targetEnemy.position.x > transform.position.x)
            //{
            //    Vector3 rotation = new Vector3(-1, 0, 0);
            //    transform.Rotate(rotation);
            //}

            //float degreesPerSecond = 90 * Time.deltaTime;
            //Vector2 direction = homing.transform.position - transform.position;
            //Quaternion targetRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);



            //Vector3 direction = new Vector3 (transform.position.x, transform.position.y, transform.position.z) - targetEnemy.transform.position;
            //transform.LookAt(direction);
            //return;
            Vector3 vectorToTarget = targetEnemy.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * speed);


            //transform.up = currDir;
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
