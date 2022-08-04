using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerPlacement : MonoBehaviour
{

    private GameObject panel,  tower;
    public GameObject towerHijau, towerKuning, towerMerah;
    public string warna;

    // Start is called before the first frame update
    void Start()
    {

        
        if (warna == "hijau")
        {
           panel = GameObject.FindWithTag("panelhijau");
            tower = towerHijau;
        }

        if (warna == "kuning")
        {
            panel = GameObject.FindWithTag("panelkuning");
            tower = towerKuning;
        }

        if (warna == "merah")
        {
            panel = GameObject.FindWithTag("panelmerah");
            tower = towerMerah;
        }
    }

    public void pencetTower()
    {
        GameManager.isDragged = true;

    }

    public void spawnTower()
    {
        GameManager.isDragged = false;
        //Destroy(gameObject);
        GameObject towerBut = (GameObject)Instantiate(tower, panel.transform);
        towerBut.name = "tower " + warna;
        //Instantiate(tower, panel.transform);

        Destroy(gameObject);

        // Destroy(gameObject);
    }

    private void OnMouseDrag()
    {

        // move the object by the position of the cursor
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }
}
