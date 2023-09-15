using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;

public class corvette_script : MonoBehaviour
{

    public GameObject explosion;
    public GameObject Missile;
    Transform targetEnemy;
    bool targetLock = false;
    public Transform homing;
    public float speed;
    bool shoot;
    bool enemyActive = true;
    float fireRate = 0.5f;
    float timer;


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

        shoot = false;
        GameObject randomEnemy = FindRandomTarget();

        targetEnemy = randomEnemy.transform;
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            targetEnemy = GameObject.FindGameObjectWithTag("Player").transform;
        }
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
            if(targetEnemy != null)
            {
                return;
            }
        }
        if (targetEnemy == null)
        {
            targetEnemy = GameObject.FindGameObjectWithTag("Player").transform;
            shoot = false;
        }




        Invoke("Target", 0.5f);

        if (targetLock == true)
        {
            Vector3 vectorToTarget = targetEnemy.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 5;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * speed);
        }




        if (shoot == true && timer > fireRate)
        {
            Vector3 targ = targetEnemy.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Instantiate(Missile, transform.position, transform.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;


    }

    void Target()
    {
        targetLock = true;
        Invoke("Shoot", 1f);
    }

    void Shoot()
    {
        shoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(newExplosion, 1);
    }


}
