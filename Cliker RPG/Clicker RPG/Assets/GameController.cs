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
    public double money;

    public Text healthText;
    public Text enemyText;
    public Text stageText;
    public Text dpsText;
    public Text moneyText;

    public Image healthbar;

    public void Start()
    {
        healthCap = 20;
        health = healthCap;
        dpc = 1;
        enemy = 0;
        stage = 1;
        money = 0;
    }

    public void Update()
    {
        healthText.text = health + "/" + healthCap + " HP";
        enemyText.text = enemy + "/" + "10";
        stageText.text = "Stage - " + stage;
        moneyText.text = money.ToString();
        dpsText.text = "" + dpc;

        healthbar.fillAmount = (float)(health / healthCap);
    }

    public void Hit()
    {
        health = health - dpc;

        if (health <= 0)
        {
            health = healthCap;

            enemy += 1;

            money += Random.Range(1, 5);

            if (enemy > 10)
            {
                enemy = 0;
                stage = stage + 1;
            }

        }
    }

    public void BuyDPS()
    {
        if (money >= 10)
        {
            dpc = 5;
            money -= 10;
        }
    }
}
