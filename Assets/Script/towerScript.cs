using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{

    [HideInInspector] public bool isDragged;
    [HideInInspector] public bool isMoved;

    private GameObject panel, tower, towerSPawn;
    public GameObject towerHijau, towerKuning, towerMerah;

    public GameObject hijau, kuning, merah;
    public string warna;

    private bool inPlace;


    private GameObject placement;
    // Start is called before the first frame update
    void Start()
    {
        if (warna == "hijau")
        {
            panel = GameObject.FindWithTag("panelhijau");
            tower = towerHijau;
            towerSPawn = hijau;
        }

        if (warna == "kuning")
        {
            panel = GameObject.FindWithTag("panelkuning");
            tower = towerKuning;
            towerSPawn = kuning;
        }

        if (warna == "merah")
        {
            panel = GameObject.FindWithTag("panelmerah");
            tower = towerMerah;
            towerSPawn = merah;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
       
            // move the object by the position of the cursor
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // set the dragged and moved condition when mouse is on drag
            isDragged = true;
            isMoved = false;
        
    }

    private void OnMouseUp()
    {

        
        //set the moved condition when mouse click goes up
        isMoved = true;

        if (inPlace)
        {
            Debug.Log("benar");

            Instantiate(towerSPawn, placement.transform.position, Quaternion.identity, placement.transform);
        }
        GameObject towerBut = (GameObject)Instantiate(tower, panel.transform.position, Quaternion.identity, panel.transform);
        towerBut.name = "tower" + warna;
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "placement")
        {
            placement = collision.gameObject;
            inPlace = true;
            Debug.Log("benar");
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "placement")
        {
            inPlace = false;
            Debug.Log("salah");
        }


    }
}
