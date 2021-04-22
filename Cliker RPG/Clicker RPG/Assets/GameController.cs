using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public double health;
    public double healthCap;
    public double dpc;
    public double enemy;
    public double stage;

    public Text healthText;
    public Text enemyText;
    public Text stageText;

    public Image healthbar;

    public void Start()
    {
        healthCap = 20;
        health = healthCap;
        dpc = 1;
        enemy = 0;
        stage = 1;
    }

    public void Update()
    {
        healthText.text = health + "/" + healthCap + " HP";
        enemyText.text = enemy + "/" + "10";
        stageText.text = "Stage - " + stage;

        healthbar.fillAmount = (float)(health / healthCap);
    }

    public void Hit()
    {
        Debug.Log("HE ENTRADO");
        health = health - dpc;

        if (health <= 0)
        {
            health = healthCap;

            enemy += 1;

            if (enemy > 10)
            {
                enemy = 0;
                stage = stage + 1;
            }

        }
    }
}
