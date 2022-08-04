using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misilleScript : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject target;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        var step = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, step);



        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            AudioPlayer.Instance.PlaySFX("hit-enemy");
            target.GetComponent<enemyScript>().health -= damage;
            Destroy(gameObject);
        }


    }
}
