using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    //public Canvas cam;

    public Camera MyCamera;
    void Start()
    {
        MyCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

    }
}
