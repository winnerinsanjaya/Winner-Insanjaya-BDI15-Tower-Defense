using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject towerHijau, towerKuning, towerMerah, panel1, panel2, panel3;
    public static bool isDragged;
    public string warnaTower;

    public float health;
    public static float playerHealth, killedEn;
    public Text killed;
    public Image healthbar;
    public GameObject gameOver;


    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        killed.text = "Killed Enemy : " + killedEn;

        healthbar.fillAmount = playerHealth / health;

        if(playerHealth <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void munculTower(string warna)
    {
        isDragged = true;
        warnaTower = warna;

    }

    public void spawnTower()
    {
        isDragged = false;

        if(warnaTower == "hijau")
        {
            Instantiate(towerHijau, panel1.transform);
        }

        if (warnaTower == "kuning")
        {
            Instantiate(towerKuning, panel2.transform);
        }

        if (warnaTower == "merah")
        {
            Instantiate(towerMerah, panel3.transform);
        }


    }

    public void playAgain()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
