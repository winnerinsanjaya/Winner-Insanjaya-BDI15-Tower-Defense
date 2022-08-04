using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyScript : MonoBehaviour
{


    public float health, orihealth;
    public Image red;

    public GameObject to1,to2,to3,to4,to5;

    public bool d1, d2, d3, d4, d5;

    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        orihealth = health;
        d1 = true;

        to1 = GameObject.FindWithTag("to1");
        to2 = GameObject.FindWithTag("to2");
        to3 = GameObject.FindWithTag("to3");
        to4 = GameObject.FindWithTag("to4");
        to5 = GameObject.FindWithTag("to5");
    }

    // Update is called once per frame
    void Update()
    {


        red.fillAmount = health / orihealth;

        if(health <= 0)
        {

            AudioPlayer.Instance.PlaySFX("enemy-die");
            GameManager.killedEn += 1;
            GameObject prnt = transform.parent.gameObject;
            Destroy(prnt);
        }

        if(transform.position == to1.transform.position)
        {
            d1 = false;
            d2 = true;
        }

        if (transform.position == to2.transform.position)
        {
            d2 = false;
            d3 = true;
        }

        if (transform.position == to3.transform.position)
        {
            d3 = false;
            d4 = true;
        }

        if (transform.position == to4.transform.position)
        {
            d4 = false;
            d5= true;
        }

        if (transform.position == to5.transform.position)
        {
            d5 = false;
           
        }

        //goto 1
        if (d1)
        {
            var step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, to1.transform.position, step);


            Vector3 dir = to1.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (d2)
        {
            var step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, to2.transform.position, step);


            Vector3 dir = to2.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (d3)
        {
            var step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, to3.transform.position, step);


            Vector3 dir = to3.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (d4)
        {
            var step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, to4.transform.position, step);


            Vector3 dir = to4.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (d5)
        {
            var step = speed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, to5.transform.position, step);


            Vector3 dir = to5.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "endpoint")
        {
            GameManager.playerHealth -= 5;
            Destroy(gameObject);
        }


    }
}
