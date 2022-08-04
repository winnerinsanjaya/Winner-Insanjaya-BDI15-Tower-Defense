using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{


    public float cooldown = 5;
    private float cooldownTimer;
    public int randomize;

    public GameObject enemyFabs1, enemyFabs2, posSpawn, enemyContainer, enemyObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomize = Random.Range(1, 3);
        if (randomize == 1)
        {
            enemyObj = enemyFabs1;

        }

        if (randomize == 2)
        {
            enemyObj = enemyFabs2;
        }

        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;


        Instantiate(enemyObj, posSpawn.transform.position, Quaternion.identity, enemyContainer.transform);
    }
        
}
