using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public GameObject bullet, posBullet;
    public GameObject other;

    public bool canSpawnBullet;

    public float cooldown = 5;
    private float cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        FindClosestEnemy();
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;

                if(curDistance <= 15)
                {

                    Vector3 dir = go.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    other = go;

                    spawnBul();
                }
            }
        }
        return closest;
    }

    public void spawnBul()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        Instantiate(bullet, posBullet.transform.position, Quaternion.identity);
        bullet.GetComponent<misilleScript>().target = other;
    }
}
